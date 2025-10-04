using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public LayerMask playerLayer;
    private int damageAmount = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, .1f, playerLayer);
        if (hit.Length > 0)
        {
            if (hit[0].gameObject.tag == MyTags.PLAYER_TAG)
            {
                hit[0].gameObject.GetComponent<PlayerHealthScript>().DealDamage(damageAmount);
            }
        }
        
    }
}
