using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameTree tree;
    void Start()
    {
        tree = FindObjectOfType<GameTree>();
    }

    void FixedUpdate()
    {
        tree.AddWaterPercentage(-Time.fixedDeltaTime * 0.02f);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
