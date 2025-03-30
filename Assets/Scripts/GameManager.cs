using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPlaying; 
    public GameTree tree;
    public EventManager eventManager;
    public float secondsBetweenEvents = 30f;

    public GameObject winUI;
    public GameObject loseUI;
    public TMP_Text loseUIText;

    public AudioSource audioSource;

    void Start()
    {
        isPlaying = true;

        Invoke("EventLoop", 15f);
        // eventManager.TriggerEvent(6);
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

        tree.secondsInStage += Time.fixedDeltaTime;
        if (tree.secondsInStage >= tree.secondsPerGrowth)
        {
            if (tree.stage >= tree.stageSprites.Length - 1)
            {
                Win(); // reached max stage, win the game!
                return;
            }
            tree.AdvanceStage();
        }

        tree.AddWater(-Time.fixedDeltaTime * tree.waterLossPerSecond);
        tree.AddFood(-Time.fixedDeltaTime * tree.foodLossPerSecond);

        // game over conditions
        if (tree.water <= 0)
        {
            Lose("Your tree didn't get enough water and died!");
        }
        else if (tree.water > tree.maxWater)
        {
            Lose("Your tree got too much water and died!");
        }

        if (tree.food <= 0)
        {
            Lose("Your tree didn't get enough nutrients and died!");
        }
        else if (tree.food > tree.maxFood)
        {
            Lose("Your soil was oversaturated, your tree died!");
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

    public void EndGame() {
        isPlaying = false;
        CancelInvoke("EventLoop");
        audioSource.Stop();
    }

    public void Win()
    {
        EndGame();
        winUI.SetActive(true);
    }

    public void Lose(string message)
    {
        EndGame();
        loseUI.SetActive(true);
        loseUIText.text = message;
    }
}
