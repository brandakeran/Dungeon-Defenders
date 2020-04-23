using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    private int timeTotal = 2;
    private float timeElapsed = 0.0f;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeTotal)
        {
            Instantiate(enemy, new Vector3(Random.Range(-10, 10), 4, Random.Range(-10, 10)), Quaternion.identity);
            timeElapsed -= timeTotal;
        }

    }
}
