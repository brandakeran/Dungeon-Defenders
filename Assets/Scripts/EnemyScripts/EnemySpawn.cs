using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    private int timeTotal = 2;
    private float timeElapsed = 0.0f;
    public int numberOfEnemies = 0;
    public int wave = 0;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (numberOfEnemies <= 0)
        {
            wave++;
            numberOfEnemies = wave * 5;
            for(int i = 0; i < numberOfEnemies; i++)
            {
                Instantiate(enemy, new Vector3(Random.Range(-10, 10), 4, Random.Range(0, 10)), Quaternion.identity);
            }
        }

    }
}
