using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startHealth = 1;
    public int curHealth;
    NavMeshAgent nav;

    AudioSource[] audios;
    Animator anim;

    private bool Dead;

    void OnEnable()
    {
        curHealth = startHealth;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
        Dead = false;
    }

    public void TakeDamage(int amount)
    {
        audios[0].Play();
        curHealth -= amount;

        if(curHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (Dead == false)
        {
            nav.enabled = false;
            anim.SetTrigger("Die");
            TutorialKill.kills += 1;
            if (gameObject.CompareTag("Boss"))
            {
                FinalLvlScript.BossKilled = true;
            }
            Dead = true;
            Destroy(gameObject,0.2f);
        }
    }
}
