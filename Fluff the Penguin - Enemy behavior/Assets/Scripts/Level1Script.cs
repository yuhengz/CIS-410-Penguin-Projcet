using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Script : MonoBehaviour
{
    public Text eventText;
    public Text controlText;
    public Text killText;
    public Text hint;
    public GameObject teleporter;

    private static int goalkills;
    private static int kills;
    private bool isCleared;
    // Start is called before the first frame update
    void OnEnable()
    {
        eventText.text = "Oh, it's just a checkpoint...";
        controlText.text = "AND A TRAP!";
        goalkills = 20;
        isCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        kills = TutorialKill.kills - 5;
        if (isCleared == false)
        {
            if (kills == goalkills)
            {
                eventText.text = "Whew, that was close...";
                controlText.text = "Now let's keep moving to find that rock";
                killText.text = "";
                hint.text = "Hint: By the way, there's pickups scattered throughout the levels!";
                teleporter.SetActive(true);
                isCleared = true;
            }
            else
            {
                killText.text = "Kills: " + kills + "/" + goalkills;
            }
        }
       

    }
}
