using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameTree : MonoBehaviour
{
    public int stage;
    public Sprite[] stages;

    public float water;
    public float maxWater = 300f;
    public float startWaterPercent = 0.5f;
    public float waterLossPerSecond;
    public float defaultWaterLossPerSecond = 1f;
    [SerializeField] Image waterBar;
    [SerializeField] Slider waterBarSlider;
    [SerializeField] Gradient waterBarGradient;
    public float food;
    public float maxFood = 300f;
    public float startFoodPercent = 0.5f;
    public float foodLossPerSecond;
    public float defaultFoodLossPerSecond = 0.5f;
    [SerializeField] Image foodBar;
    [SerializeField] Slider foodBarSlider;
    [SerializeField] Gradient foodBarGradient;

    public void SetWater(float amount)
    {
        water = amount;

        waterBarSlider.value = math.clamp(water / maxWater, 0f, 1f);
        waterBar.color = waterBarGradient.Evaluate(waterBarSlider.value);
    }

    public void SetFood(float amount)
    {
        food = amount;

        foodBarSlider.value = math.clamp(food / maxFood, 0f, 1f);
        foodBar.color = foodBarGradient.Evaluate(foodBarSlider.value);
    }

    public void AddWater(float amount)
    {
        SetWater(water + amount);
    }

    public void AddWaterPercentage(float percentage)
    {
        AddWater(maxWater * percentage);
    }

    public void AddFood(float amount)
    {
        SetFood(food + amount);
    }

    public void AddFoodPercentage(float percentage)
    {
        AddFood(maxFood * percentage);
    }
}
