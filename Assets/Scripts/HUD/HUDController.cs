using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image canUI;

    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color alphaColor;


    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.currentWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.currentCarrots / playerItems.carrotsLimit;
        fishUIBar.fillAmount = playerItems.currentFishes / playerItems.fishesLimit;
        
        //Nota: Otimizar processos chamando-os apenas quando são alterados
        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObject)
            {
                toolsUI[i].color = selectedColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
