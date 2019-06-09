using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{
    public float timeBetwAtk = 0.5f; //Seconds between attacks.
    public float timeBetwThrows = 3.0f;
    public int atkdmg = 40; //Amount of health taken from attack.
    public float distance;
    public Rigidbody projectile;
    public Transform fireTrans;
    public float throwForce = 60f;

    AudioSource[] audios;
    Animator anim;
    GameObject penguin;
    PenguinHealth penHP;

    bool PenInRange;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        penguin = GameObject.FindGameObjectWithTag("Player");
        penHP = penguin.GetComponent<PenguinHealth>();
        audios = GetComponents<AudioSource>();

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If entering collider is the player
        if (other.gameObject == penguin)
        {
            //Player/penguin is in range.
            PenInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If exiting collider is the player
        if (other.gameObject == penguin)
        {
            //Player/penguin is in not range.
            PenInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Add time
        timer += Time.deltaTime;

        distance = Vector3.Distance(transform.position, penguin.transform.position);

        //When the timer exceeds time between attacks and when player/penguin is in range.
        if (timer >= timeBetwAtk && PenInRange && PenguinHealth.curHealth > 0)
        {
            //Take a swing.
            anim.SetTrigger("AttackPlayer");
            Attack();
            anim.SetTrigger("KeepWalking");
        }

        if(timer >= timeBetwThrows && PenInRange == false && PenguinHealth.curHealth > 0 && distance > 25)
        {
            anim.SetTrigger("Throw");
            Throw();
            anim.SetTrigger("KeepWalking");
        }

        if (PenguinHealth.lives == 0)
        {
            anim.SetTrigger("PlayerDead");
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    void Attack()
    {
        //Reset timer
        timer = 0f;

        //If player/penguin still have HP
        if (PenguinHealth.curHealth > 0)
        {
            //Damage player.
            audios[1].Play();
            penHP.TakeDamage(atkdmg);
        }
    }

    void Throw() 
    {
        audios[2].Play(); 
        timer = 0f;

        Rigidbody projInstance = Instantiate(projectile, fireTrans.position, fireTrans.rotation) as Rigidbody;

        projInstance.velocity = throwForce * fireTrans.forward;
    }
}
