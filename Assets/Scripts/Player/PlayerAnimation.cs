using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        OnCut();
        OnDig();
        OnWatering();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling)
            {
                animator.SetTrigger("isRolling");
            }
            else
            {
                animator.SetInteger("transition", 1);
            }
        }
        else
        {
            animator.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            animator.SetInteger("transition", 2);
        }
    }

    #endregion

    #region Action

    void OnCut()
    {
        if (player.isCutting)
        {
            animator.SetInteger("transition", 3);
        }
    }

    void OnDig()
    {
        if (player.isDigging)
        {
            animator.SetInteger("transition", 4);
        }
    }

    void OnWatering()
    {
        if (player.isWatering)
        {
            animator.SetInteger("transition", 5);
        }
    }

    #endregion


}
