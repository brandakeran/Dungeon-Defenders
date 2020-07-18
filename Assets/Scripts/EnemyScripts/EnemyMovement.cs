using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public GameObject target;
    bool targetInRange;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       agent.destination = target.transform.position;

    }
}
