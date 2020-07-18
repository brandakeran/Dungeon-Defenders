using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordAttack : MonoBehaviour
{
    public GameObject self;
    Animator animator;
    Dictionary<GameObject, bool> collided;
    // Start is called before the first frame update
    void Start()
    {
        animator = self.GetComponent<Animator>();
        collided = new Dictionary<GameObject, bool>();

    }

    // Update is called once per frame  
    void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.5)
            {

                GameObject enemy = other.gameObject;
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    if (!collided.ContainsKey(enemy))
                    {
                        collided.Add(enemy, true);
                        enemyHealth.TakeDamage(50);
                    }

                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        GameObject enemy = other.gameObject;
        if (collided.ContainsKey(enemy))
        {
            collided.Remove(enemy);
        }
    }
}
