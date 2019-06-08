using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialKill : MonoBehaviour
{
    public static int kills;
    public static int goalkills;

    public GameObject triggerPoint;
    public GameObject GoalWall;

    public Text killsText;
    public Text controlText;
    public Text eventText;

    private bool isCleared;
    // Start is called before the first frame update
    void Start()
    {
        killsText.text = "";
        goalkills = 5;
        kills = 0;
        isCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerPoint.activeInHierarchy == false && isCleared == false)
        {
            if (kills == goalkills)
            {
                killsText.text = "CLEAR!";
                eventText.text = "Nice work, now you're ready to go!";
                controlText.text = "Good luck finding the shiniest rock!";
                GoalWall.SetActive(false);
                isCleared = true;
            }
            else
            {
                killsText.text = "Kill: " + kills + "/" + goalkills;
            }
        }
    }
}
