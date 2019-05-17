using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Text controlText;
    public Text eventText;
    public int guideCount;
    public GameObject[] guidePoints;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Checkpoint;
    public GameObject Manager;

    private EnemyManager[] scripts;
    // Start is called before the first frame update
    void Start()
    {
        eventText.text = "Welcome,Fluff the Penguin!";
        controlText.text = "Move: Arrow Keys/WASD keys";
        guideCount = 0;
        scripts = Manager.GetComponents<EnemyManager>();
        for(int i = 0; i < scripts.Length; i++)
        {
            scripts[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Checkpoint.activeInHierarchy == false)
        {
            eventText.text = "You Cleared the Tutorial!";
            controlText.text = "Congratulations!";
        }
        else
        {
            CheckGuide(guidePoints, guideCount);
            if (guideCount < 7 && guidePoints[guideCount].activeInHierarchy == false)
            {
                guideCount = guideCount + 1;
            }
        }
    }

    void CheckGuide(GameObject[] Points, int Count)
    {
        if(Points[Count].activeInHierarchy == false && Count == 0)
        {
            eventText.text = "Try and jump across this gap";
            controlText.text = "Jump: Spacebar";
        }
        else if (Points[Count].activeInHierarchy == false && Count == 1)
        {
            eventText.text = "Good, now let's review power ups";
            controlText.text = "";
            Wall1.SetActive(false);

        }
        else if (Points[Count].activeInHierarchy == false && Count == 2)
        {
            eventText.text = "";
            controlText.text = "Red Cylinder: Power-up";
        }
        else if (Points[Count].activeInHierarchy == false && Count == 3)
        {
            eventText.text = "";
            controlText.text = "Green Cube: Health";
        }
        else if (Points[Count].activeInHierarchy == false && Count == 4)
        {
            eventText.text = "";
            controlText.text = "Yellow Capsule: Speed-up";
        }
        else if (Points[Count].activeInHierarchy == false && Count == 5)
        {
            eventText.text = "Now, step to the center...";
            controlText.text = "";
            Wall2.SetActive(false);

        }
        else if (Points[Count].activeInHierarchy == false && Count == 6)
        {
            eventText.text = "IT's TIME FOR A DEATH BATTLE!";
            controlText.text = "Attack: B key";
            Wall2.SetActive(true);
            Manager.SetActive(true);
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].enabled = true;
            }
        }
    }
}
