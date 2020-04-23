using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public GameObject target;
    bool targetInRange;



    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(target.transform);

        transform.position += transform.forward * speed * Time.deltaTime;

    }
}
