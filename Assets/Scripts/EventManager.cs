using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameTree tree;
    public GameObject eventPopup;
    public TMP_Text eventPopupText;
    public float hideEventPopupDelay = 5.0f;
    public float eventDuration = 20.0f;
    private int totalEvents = 7;

    public void TriggerEvent(int eventID)
    {
        ShowEventPopup();
        eventPopupText.text = ""; // Clear previous text

        switch (eventID)
        {
            case 0:
                eventPopupText.text = "Everything is perfectly normal. It's a nice day out!";
                break;
            case 1:
                eventPopupText.text = "The ozone layer is disappearing. A heat wave dries your soil of its water and nutrients.";
                HeatWave();
                break;
            case 2:
                eventPopupText.text = "A sudden, unexpected storm appears! Your soil slowly fills with water.";
                Storm();
                break;
            case 3:
                eventPopupText.text = "Because of air pollution, smoke is everywhere! Click on one to remove it!";
                Smoke();
                break;
            case 4:
                eventPopupText.text = "High concentrations of greenhouse gas led to acid rain. Your soil is now less fertile.";
                AcidRain();
                break;
            case 5:
                eventPopupText.text = "It's abnormally hot for this time of year. The heat causes your tree to lose water.";
                TooHot();
                break;
            case 6:
                eventPopupText.text = "Litter has been dumped in your area! Click on one to remove it!";
                Trash();
                break;
            default:
                Debug.Log("No event exists for ID: " + eventID);
                break;
        }

        Invoke("ResetLossRates", eventDuration);
        Invoke("HideEventPopup", hideEventPopupDelay);
    }

    public void TriggerEvent()
    {
        TriggerEvent(Random.Range(0, totalEvents));
    }

    public void HeatWave()
    {
        tree.AddWaterPercentage(-0.1f);
        tree.AddFoodPercentage(-0.1f);
        tree.waterLossPerSecond = tree.defaultWaterLossPerSecond * 3f;
        tree.foodLossPerSecond = tree.defaultFoodLossPerSecond * 3f;
    }

    public void Storm()
    {
        // soil gains water
        tree.waterLossPerSecond = -tree.defaultWaterLossPerSecond * 0.25f;
    }

    public GameObject smokePrefab;
    public void Smoke()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(smokePrefab, new Vector2(Random.Range(-7.5f, 2.5f), Random.Range(-3.5f, 2.0f)), Quaternion.identity);
        }
    }

    public void AcidRain()
    {
        tree.AddWaterPercentage(0.05f);
        tree.AddFoodPercentage(-0.25f);
        tree.foodLossPerSecond = tree.defaultFoodLossPerSecond * 3f;
    }

    public void TooHot()
    {
        tree.AddWaterPercentage(-0.35f);
    }
    
    public GameObject trashPrefab;
    public void Trash()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(trashPrefab, new Vector2(Random.Range(-7.5f, 2.5f), Random.Range(-4.5f, -3.0f)), Quaternion.identity);
        }
    }

    public void ResetLossRates()
    {
        tree.waterLossPerSecond = tree.defaultWaterLossPerSecond;
        tree.foodLossPerSecond = tree.defaultFoodLossPerSecond;
    }

    public void ShowEventPopup()
    {
        if (eventPopup != null)
        {
            eventPopup.SetActive(true);
        }
    }

    public void HideEventPopup()
    {
        if (eventPopup != null)
        {
            eventPopup.SetActive(false);
        }
    }
}
