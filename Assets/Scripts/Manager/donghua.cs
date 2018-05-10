using UnityEngine;
using System.Collections;

public class donghua : MonoBehaviour
{

    public Sprite[] Sprites;
    public float speed;
    private SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        int index = (int)(Time.time * speed) % Sprites.Length;
        spriterenderer.sprite = Sprites[index];
    }
}