using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalLvlScript : MonoBehaviour
{
    public GameObject trigger;
    public GameObject ShiniestRock;
    public GameObject spawnManager;
    public BossSpawn[] spawns;
    public Text eventText;
    public Text controlText;

    public static bool BossKilled;
    private bool started;
    private bool triggered;
    private bool obtaining;

    private void Start()
    {
        spawns = spawnManager.GetComponents<BossSpawn>();
        triggered = false;
        started = false;
        obtaining = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (started == false)
        {
            eventText.text = "You are now at the final level...";
            controlText.text = "Looks like another penguin appeared... Fight for the rock!";
            started = true;
        }
    }


    // Start is called before the first frame update
    private void Update()
    {
        if (trigger.activeInHierarchy == false && triggered == false)
        {
            eventText.text = "";
            controlText.text = "";
            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i].enabled = true;
            }
            triggered = true;
        }

        if(BossKilled == true)
        {
            if (ShiniestRock.activeInHierarchy == false && obtaining == false)
            {
                ShiniestRock.SetActive(true);
                obtaining = true;
            }
        }
    }
}
