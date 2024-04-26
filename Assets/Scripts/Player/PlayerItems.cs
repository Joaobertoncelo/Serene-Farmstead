using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private int currentWater;
    [SerializeField] private int waterLimit;

    public int TotalWood { get => totalWood; set { totalWood = value; } }
    public int CurrentWater { get => currentWater; set { currentWater = value; } }

    public void WaterLimit(int water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}
