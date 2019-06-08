using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl3Trigger : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player") && started == false)
        {
            eventText.text = "Now entering Level 3...";
            controlText.text = "This house has got to have an exit (and a shiny rock...)";
            started = true;
        }
    }
}
