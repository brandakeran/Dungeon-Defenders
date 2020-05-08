using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    bool isDead;
    public EnemySpawn spawner;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        print(spawner);
        spawner.numberOfEnemies--;
        Destroy(gameObject);
    }
}
