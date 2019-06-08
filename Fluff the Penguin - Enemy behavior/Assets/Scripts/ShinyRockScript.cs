using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShinyRockScript : MonoBehaviour
{
    public Text eventText;
    public Text controlText;
    public GameObject penguin;
    PenguinMove penMove;
    public static bool obtained;

    private void Start()
    {
        penMove = penguin.GetComponent<PenguinMove>();
        obtained = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && obtained == false)
        {
            penMove.enabled = false;
            eventText.text = "You did it! You found the shiniest rock!";
            controlText.text = "Now... How we gonna get back home?...";
            obtained = true;
            gameObject.SetActive(false);
        }
    }
}
