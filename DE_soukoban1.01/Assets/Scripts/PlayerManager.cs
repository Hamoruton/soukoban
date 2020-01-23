using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public void Move(Vector2 position, DIRECTION direction)
    {
        transform.position = position;
        spriteRenderer.sprite = sprites[(int)direction];
    }
}