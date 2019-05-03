using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10.0f;
    private float turnspd = 180f;
    private float turnInput;
    private float move;
    private float jumpForce = 12f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
        Jump();

        Animating(v);
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * move * speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = turnInput * turnspd * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void Jump()
    {
        Vector3 jump = new Vector3(move, 0.0f, turnInput);

        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Animating(float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = !Equals(v,0f);

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
