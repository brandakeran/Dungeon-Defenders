using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float timer;
    public float timeBetweenAttack;
    bool targetInRange;
    public EnemyMovement move;
    public GameObject target;
    public EnemyHealth enemyHealth;
    PlayerHealth targetHealth;

    public int attackDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        target = move.target;
        targetHealth = target.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer >= timeBetweenAttack && targetInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)
        {
            targetInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            targetInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if(targetHealth.currentHealth > 0)
        {
            targetHealth.TakeDamage(attackDamage);
        }
    }
}
