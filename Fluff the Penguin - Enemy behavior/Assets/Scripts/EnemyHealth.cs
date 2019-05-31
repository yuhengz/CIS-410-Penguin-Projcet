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

    Animator anim;

    void OnEnable()
    {
        curHealth = startHealth;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;

        if(curHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        nav.enabled = false;
        anim.SetTrigger("Die");
        TutorialKill.kills += 1;
        gameObject.SetActive(false);
    }
}
