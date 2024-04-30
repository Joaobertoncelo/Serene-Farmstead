using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Current Values")]
    [SerializeField] private int _currentWood;
    [SerializeField] private int _currentCarrots;
    [SerializeField] private float _currentWater;
    [Header("Limits")]
    private float _waterLimit = 50;
    private float _woodLimit = 10;
    private float _carrotsLimit = 10;

    public int currentWood { get => _currentWood; set { _currentWood = value; } }
    public float currentWater { get => _currentWater; set { _currentWater = value; } }
    public int currentCarrots { get => _currentCarrots; set => _currentCarrots = value; }
 
    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float carrotsLimit { get => _carrotsLimit; set => _carrotsLimit = value; }
    
    public void ControlMaxWater(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}
