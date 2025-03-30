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
    public float eventDuration = 30.0f;
    private int totalEvents = 3;
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
                eventPopupText.text = "A sudden storm has passed! Your soil is filled with water.";
                Storm();
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
        tree.AddWater(-tree.maxWater * 0.1f);
        tree.AddFood(-tree.maxFood * 0.1f);
        tree.waterLossPerSecond = tree.defaultWaterLossPerSecond * 3f;
        tree.foodLossPerSecond = tree.defaultFoodLossPerSecond * 3f;
    }

    public void Storm()
    {
        tree.AddWater(tree.maxWater * 0.2f);
        tree.waterLossPerSecond = tree.defaultWaterLossPerSecond * 0.5f;
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
