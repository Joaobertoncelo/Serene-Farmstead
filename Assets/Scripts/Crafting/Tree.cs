using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject woodPrefab;
    private int numberOfWoodsCreatedOnChop;

    [SerializeField] private ParticleSystem leafs;

    private bool isCutted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        treeHealth--;

        animator.SetTrigger("isHit");
        leafs.Play();

        if(treeHealth <= 0)
        {
            numberOfWoodsCreatedOnChop = Random.Range(2, 4);
            for(int i = 0; i < numberOfWoodsCreatedOnChop; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }
            animator.SetTrigger("cutted");
            isCutted = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCutted)
        {
            OnHit();
        }
    }
}
