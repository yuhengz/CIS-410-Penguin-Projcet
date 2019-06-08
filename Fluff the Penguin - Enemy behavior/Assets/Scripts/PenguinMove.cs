using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 20.0f;
    private float turnspd = 180f;
    private float turnInput;
    private float move;
    private float jumpForce = 15f;
    public GameObject projectile;
    Animator anim;
    AudioSource[] audios;

    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Ground") && grounded == false)
        {
            grounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            audios[1].Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();

        Animating(v);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Speed-up"))
        {
            audios[3].Play();
            other.gameObject.SetActive(false);
            speed = 2.0f * speed;
        }
        else if (other.gameObject.CompareTag("Guide"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Power-up"))
        {
            audios[4].Play();
            ProjectileHit.damage = 2 * ProjectileHit.damage;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("ShinyRock"))
        {
            audios[5].Play();
        }
    }

    void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * move * speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
    }

    void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = turnInput * turnspd * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void Animating(float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = !Equals(v,0f);

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
