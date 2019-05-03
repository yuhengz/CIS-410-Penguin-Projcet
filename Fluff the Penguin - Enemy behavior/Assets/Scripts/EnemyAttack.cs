using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetwAtk = 0.5f; //Seconds between attacks.
    public int atkdmg = 10; //Amount of health taken from attack.

    Animator anim;
    GameObject penguin;
    PenguinHealth penHP;

    bool PenInRange;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        penguin = GameObject.FindGameObjectWithTag("Player");
        penHP = penguin.GetComponent<PenguinHealth>();

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If entering collider is the player
        if(other.gameObject == penguin)
        {
            //Player/penguin is in range.
            PenInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If entering collider is the player
        if (other.gameObject == penguin)
        {
            //Player/penguin is in range.
            PenInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Add time
        timer += Time.deltaTime;

        //When the timer exceeds time between attacks and when player/penguin is in range.
        if(timer >= timeBetwAtk && PenInRange && penHP.curHealth >0)
        {
            //Take a swing.
            anim.SetTrigger("AttackPlayer");
            Attack();
            anim.SetTrigger("KeepWalking");
        }

        if(penHP.curHealth <= 0)
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
        if(penHP.curHealth > 0)
        {
            //Damage player.
            penHP.TakeDamage(atkdmg);
        }
    }
}
