using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private GameObject houseCollider;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer roofSprite;
    [SerializeField] private SpriteRenderer wallsSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    [Header("Metrics")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Transform playerPoint;
    [SerializeField] private float timeAmount;

    private bool detectingPlayer;

    private Player player;
    private PlayerItems playerItems;
    private PlayerAnimation playerAnimation;

    private float timeCount;
    private bool isBuilding;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerItems = player.GetComponent<PlayerItems>();
        playerAnimation = playerItems.GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if ((detectingPlayer && Input.GetKeyDown(KeyCode.E)) && playerItems.currentWood >= woodAmount)
        {
            BuildingHouse();
            isBuilding = true;
            player.stopPlayer = true;
        }

        if (isBuilding)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                playerAnimation.OnHammeringEnded();
                roofSprite.color = endColor;
                wallsSprite.color = endColor;
                player.stopPlayer = false;
                houseCollider.SetActive(true);
                playerItems.currentWood -= woodAmount;
                isBuilding = false;
            }
        }
    }

    public void BuildingHouse()
    {
        playerAnimation.OnHammeringStarted();
        roofSprite.color = startColor;
        wallsSprite.color = startColor;
        playerItems.transform.position = playerPoint.position;
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
