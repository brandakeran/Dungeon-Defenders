using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float gravity = -9.8f;
    public float jumpHeight = 1;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    public float turnSmoothTime = 0.2f;
    public float turnSmoothTime2 = 0.1f;
    float turnSmoothVelocity;

    Transform cameraT;
    Animator animator;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(hor, ver);
        Vector2 inputDir = input.normalized;

        if (!animator.GetCurrentAnimatorStateInfo(1).IsName("Attacking"))
        {
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }
            else
            {
                float targetRotation = cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime2);
            }
        }
        

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attacking"))
        {
            currentSpeed = 0;
        }

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
        
        if (Input.GetKey(KeyCode.Space)){
            Jump();
        }

        if (inputDir.magnitude != 0)
        {
            float animationSpeedPercent = ((running) ? 1 : 0f) * inputDir.magnitude;
            animator.SetBool("Moving", true);
            animator.SetFloat("SpeedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void Jump()
    {
        if (controller.isGrounded && !animator.GetCurrentAnimatorStateInfo(1).IsName("Attacking"))
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }
}


