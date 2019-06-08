using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2Trigger : MonoBehaviour
{

    public Text eventText;
    public Text controlText;
    private bool started;

    private void Start()
    {
        started = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && started == false)
        {
            eventText.text = "Now entering Level 2...";
            controlText.text = "Let's check the house beyond the bridges";
            started = true;
        }
    }
}
