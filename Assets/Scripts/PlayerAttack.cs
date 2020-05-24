using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 100;
    public float range = 300f;
    public float timeBetweenShots = 2;

    Animator animator;
    GameObject hand;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hand = GameObject.Find("mixamorig:RightHand");

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetweenShots)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        timer = 0f;

        BoxCollider collider = hand.transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        collider.enabled = true;

        animator.SetTrigger("Attacking");

    }
}
