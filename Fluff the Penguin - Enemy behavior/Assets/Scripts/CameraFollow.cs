using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    private float turnspd = 3f;

    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnspd, Vector3.up) * offset;

        // Create a postion the camera is aiming for based on the offset from the target.
        transform.position = target.position + offset;
        transform.LookAt(target.position);


    }
}
