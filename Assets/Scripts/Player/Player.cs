using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private Vector2 _direction;

    private int _handlingObject;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting= value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public int handlingObject { get => _handlingObject; set => _handlingObject = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObject = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObject = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObject = 2;
        }

        OnInput();
        OnRun();
        OnRolling();

        if(handlingObject == 0)
        {
            OnCutting();
        }else if(handlingObject == 1)
        {
            OnDigging();
        }else if (handlingObject == 2)
        {
            OnWatering();
        }
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    } 

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = rollSpeed;
            _isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = runSpeed;
            _isRolling = false;
        }
    }

    #endregion

    #region Action

    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0.5f;
            _isCutting = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            _isCutting = false;
        }
    }

    void OnDigging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0.5f;
            _isDigging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            _isDigging = false;
        }
    }

    void OnWatering()
    {
        if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
        {
            speed = 0.5f;
            _isWatering = true;
        }
        if (Input.GetMouseButtonUp(0) || playerItems.currentWater <= 0)
        {
            speed = initialSpeed;
            _isWatering = false;
        }
        if(_isWatering)
        {
            playerItems.currentWater -= 0.01f;
        }
    }

    #endregion

}
