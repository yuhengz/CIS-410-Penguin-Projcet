using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1Triggers : MonoBehaviour
{
    public GameObject pickup;
    public GameObject manager;
    public GameObject spawnManager;
    public Level1Script script;
    public TougherEnemySpawn[] spawns;

    public Text controlText;
    public Text eventText;
    private bool triggered;

    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        script = manager.GetComponent<Level1Script>();
        spawns = spawnManager.GetComponents<TougherEnemySpawn>();
        triggered = false;
        started = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && started == false)
        {
            eventText.text = "Now entering Level 1...";
            controlText.text = "And look, there's a shiny rock!";
            started = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pickup.activeInHierarchy == false && triggered == false)
        {
            script.enabled = true;
            for(int i = 0; i < spawns.Length; i++)
            {
                spawns[i].enabled = true;
            }
            triggered = true;
        }
    }
}
