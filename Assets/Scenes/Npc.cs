using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float mindDistansce;
    public Transform player;
    [TextArea]
    public string chat;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < mindDistansce)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.blue;
        }
    }
}
