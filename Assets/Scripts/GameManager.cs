using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPlaying; 
    public GameTree tree;
    public EventManager eventManager;
    public float secondsBetweenEvents = 60f;

    void Start()
    {
        isPlaying = true;
        tree.water = tree.maxWater * tree.startWaterPercent;
        tree.food = tree.maxFood * tree.startFoodPercent;
        tree.waterLossPerSecond = tree.defaultWaterLossPerSecond;
        tree.foodLossPerSecond = tree.defaultFoodLossPerSecond;

        Invoke("EventLoop", 30f);
    }

    void Update()
    {
        if (!isPlaying)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        if (!isPlaying)
        {
            return;
        }

        tree.AddWater(-Time.deltaTime * tree.waterLossPerSecond);
        tree.AddFood(-Time.deltaTime * tree.foodLossPerSecond);

        // game over conditions
        if (tree.water <= 0)
        {
            EndGame("tree died, no water.");
        }
        else if (tree.water > tree.maxWater)
        {
            EndGame("tree died, over watered.");
        }

        if (tree.food <= 0)
        {
            EndGame("tree died, no food.");
        }
        else if (tree.food > tree.maxFood)
        {
            EndGame("tree died, over fed.");
        }
    }

    public void EventLoop()
    {
        if (!isPlaying)
        {
            return;
        }

        eventManager.TriggerEvent();
        Invoke("EventLoop", secondsBetweenEvents);
    }

    public void EndGame(string message) {
        isPlaying = false;
        CancelInvoke("EventLoop");
        Debug.Log(message);
    }
}
