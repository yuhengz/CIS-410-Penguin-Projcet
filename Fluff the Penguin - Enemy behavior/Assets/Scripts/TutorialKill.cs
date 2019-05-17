using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialKill : MonoBehaviour
{
    public static int kills;

    private static int goalkills;

    public GameObject triggerPoint;

    public GameObject GoalWall;

    public Text killsText;
    // Start is called before the first frame update
    void Start()
    {
        killsText.text = "";
        goalkills = 5;
        kills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerPoint.activeInHierarchy == false)
        {
            if(kills == goalkills)
            {
                killsText.text = "CLEAR!";
                GoalWall.SetActive(false);
            }
            else
            {
                killsText.text = "Kill: " + kills + "/" + goalkills;
            }
        }
    }
}
