using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinThrow : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform fireTrans;
    public float throwForce = 30f;
    public float BetweenAtks = 0.5f;

    AudioSource[] audios;
    Animator anim;
    float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (timer >= BetweenAtks)
            {
                anim.SetTrigger("Throw");
                Fire();
                anim.SetTrigger("Revert");
            }
        }
    }

    void Fire()
    {
        audios[0].Play();
        timer = 0f;

        Rigidbody projInstance = Instantiate(projectile, fireTrans.position, fireTrans.rotation) as Rigidbody;

        projInstance.velocity = throwForce*fireTrans.forward;
    }
}
