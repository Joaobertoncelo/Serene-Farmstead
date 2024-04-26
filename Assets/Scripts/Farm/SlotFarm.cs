using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount;
    private int initialDigAmount;

    private void Start()
    {
        initialDigAmount = digAmount;
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
        }

        if (digAmount <= 0)
        {
            spriteRenderer.sprite = carrot;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }
    }
}
