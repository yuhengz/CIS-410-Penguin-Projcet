using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2TrapTriggered : MonoBehaviour
{
    public Text eventText;
    public Text controlText;

    public GameObject trapSpawning;
    public TougherEnemySpawn[] spawns;

    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        spawns = trapSpawning.GetComponents<TougherEnemySpawn>();
        triggered = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && triggered == false)
        {
            eventText.text = "Fluff, you fool! There's enemy puffers in the water!";
            controlText.text = "";
            for(int i = 0; i < spawns.Length; i++)
            {
                spawns[i].enabled = true;
            }
            triggered = true;
        }
    }
}
