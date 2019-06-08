using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Script : MonoBehaviour
{
    public GameObject spawnManager;
    public ToughestEnemyScript[] spawns;

    private bool triggered;

    private void Start()
    {
        spawns = spawnManager.GetComponents<ToughestEnemyScript>();
        triggered = false;
    }


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && triggered == false)
        {
            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i].enabled = true;
            }
            triggered = true;
        }
    }
}
