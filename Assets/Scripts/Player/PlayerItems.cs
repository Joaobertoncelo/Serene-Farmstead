using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private int _currentCarrots;
    [SerializeField] private float currentWater;
    [SerializeField] private float waterLimit;

    public int currentCarrots
    {
        get { return _currentCarrots; }
        set { _currentCarrots = value; }
    }

    public int TotalWood { get => totalWood; set { totalWood = value; } }
    public float CurrentWater { get => currentWater; set { currentWater = value; } }

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}
