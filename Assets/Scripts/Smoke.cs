using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameTree tree;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    void Start()
    {
        tree = FindObjectOfType<GameTree>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void FixedUpdate()
    {
        tree.AddWaterPercentage(-Time.fixedDeltaTime * 0.01f);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
