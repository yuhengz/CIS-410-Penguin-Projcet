using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int curHealth;
    public Text HP;
    public Text GameOver;

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

        //Set initial health
        curHealth = startHealth;
        HP.text = "Health: " + curHealth;
        GameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Check if damaged to update HP UI and reset damaged flag.(Will have Health UI HUD set up here).
        if (damaged)
        {
            //*TASK*Insert HP UI coding here.
        }
        damaged = false;
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
            //DED, amen
            Death();
        }
    }

    void Death()
    {
        //Set death flag so prevent further function call.
        isDead = true;

        anim.SetTrigger("Die");

        penMove.enabled = false;

        GameOver.text = "Game Over...";
    }
}
