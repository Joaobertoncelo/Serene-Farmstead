using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
