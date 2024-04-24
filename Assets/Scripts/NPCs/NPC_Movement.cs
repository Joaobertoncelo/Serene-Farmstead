using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private int nextPath;

    [SerializeField] private List<Transform> possiblePaths = new List<Transform>();

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, possiblePaths[nextPath].position, speed* Time.deltaTime);
        if(Vector2.Distance(transform.position, possiblePaths[nextPath].position) < 0.1f)
        {
            if(nextPath < possiblePaths.Count - 1)
            {
                nextPath++;
            }
            else
            {
                nextPath = 0;
            }
        }

        Vector2 npcDirection = possiblePaths[nextPath].position - transform.position;

        if (npcDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (npcDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
