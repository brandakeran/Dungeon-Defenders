using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attacking"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                collider.enabled = false;
                enemyHealth.TakeDamage(50);
            }
        }
        
    }
}
