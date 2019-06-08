using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    GameObject penguin;
    PenguinHealth penHP;

    private void Start()
    {
        penguin = GameObject.FindGameObjectWithTag("Player");
        penHP = penguin.GetComponent<PenguinHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == penguin)
        {
            penHP.TakeDamage(PenguinHealth.curHealth);
            if(PenguinHealth.lives <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
