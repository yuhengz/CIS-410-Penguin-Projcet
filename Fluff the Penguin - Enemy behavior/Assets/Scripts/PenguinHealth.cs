using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinHealth : MonoBehaviour
{
    public static int startHealth = 100;
    public static int curHealth;
    public Text controlText;
    public Text eventText;
    public Text HP;
    public Text GameOver;
    public static Vector3 revivePoint;
    public static int lives;

    AudioSource[] audios;
    Animator anim;
    PenguinMove penMove;

    bool isDead;
    bool damaged;
    // Start is called before the first frame update
    void Awake()
    {
        //Set up references.
        anim = GetComponent<Animator>();
        penMove = GetComponent<PenguinMove>();
        audios = GetComponents<AudioSource>();

        //Set initial health and lives
        curHealth = startHealth;
        HP.text = "Health: " + curHealth;
        GameOver.text = "";
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        damaged = false;
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            revivePoint = other.gameObject.transform.position;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Health"))
        {
            other.gameObject.SetActive(false);
            audios[2].Play();
            curHealth += 20;
            HP.text = "Health: " + curHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        //Set damaged flag
        damaged = true;

        //Reduce current health by amount number.
        curHealth -= amount;
        HP.text = "Health: " + curHealth;

        //Checks if player/penguin lost all its health and death flag is not set.
        if (curHealth <= 0 && !isDead)
        {
            HP.text = "Health: " + 0;
            lives -= 1;
            if (lives >= 1)//if you got some lives left...
            {//respawn to checkpoint
                transform.position = revivePoint;
                curHealth = startHealth;
                HP.text = "Health: " + curHealth;
                controlText.text = "You now have "+ lives + " lives left...";
                eventText.text = "";
            }
            else
            {
                //DED, amen
                Death();
            }

        }
    }

    void Death()
    {
        //Set death flag so prevent further function call.
        isDead = true;

        anim.SetTrigger("Die");

        penMove.enabled = false;

        controlText.text = "";
        eventText.text = "";
        GameOver.text = "Game Over...";

    }
}
