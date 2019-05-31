using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinJump : MonoBehaviour
{
    private CharacterController control;

    private float vertVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.isGrounded)
        {
            vertVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vertVelocity = jumpForce;
            }
        }
        else
        {
            vertVelocity -= gravity * Time.deltaTime;
        }

        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = vertVelocity;
        movement.z = Input.GetAxis("Vertical");
        control.Move(movement * Time.deltaTime);
    }
}
