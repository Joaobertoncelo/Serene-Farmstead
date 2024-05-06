using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Current Values")]
    [SerializeField] private int _currentWood;
    [SerializeField] private int _currentCarrots;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _currentFishes;

    [Header("Limits")]
    private float _waterLimit = 50;
    private float _woodLimit = 10;
    private float _carrotsLimit = 10;
    private float _fishesLimit = 10;

    public int currentWood { get => _currentWood; set { _currentWood = value; } }
    public float currentWater { get => _currentWater; set { _currentWater = value; } }
    public int currentCarrots { get => _currentCarrots; set => _currentCarrots = value; }
    public int currentFishes { get => _currentFishes; set => _currentFishes = value; }

    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float carrotsLimit { get => _carrotsLimit; set => _carrotsLimit = value; }
    public float FishesLimit { get => _fishesLimit; set => _fishesLimit = value; }

    public void ControlMaxWater(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}
