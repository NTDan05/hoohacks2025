using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
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
        tree.AddFoodPercentage(-Time.fixedDeltaTime * 0.02f);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
