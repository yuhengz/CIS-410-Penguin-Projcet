using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform Destination;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform penguinPos = other.gameObject.GetComponent<Transform>();
            penguinPos.position = Destination.position;
        }
    }
}
