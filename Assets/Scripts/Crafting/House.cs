using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private bool detectingPlayer;

    private PlayerItems playerItems;

    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.currentWood>10)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
