using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int fishProbability;

    private PlayerAnimation playerAnimation;
    private PlayerItems player;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnimation.OnStartFishing();
        }
    }

    public void OnFishing()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= fishProbability)
        {
            Debug.Log("pescou");
        }
        else
        {
            Debug.Log("Não pescou");
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
