using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Peng;            // The position that that camera will be following.
    private float turnspd = 3f;
    private Transform target;
    private Rigidbody body;

    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        // Calculate the initial offset.
        target = Peng.GetComponent<Transform>();
        body = Peng.GetComponent<Rigidbody>();
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnspd, Vector3.up) * offset;

        // Create a postion the camera is aiming for based on the offset from the target.
        transform.position = target.position + offset;
        transform.LookAt(target.position);

        if (Input.GetKeyDown(KeyCode.R))
        {
            body.constraints = RigidbodyConstraints.FreezeRotationY;
            body.constraints = ~RigidbodyConstraints.FreezeRotationY;
            body.constraints = ~RigidbodyConstraints.FreezePosition;
            Vector3 reset = target.eulerAngles;
            reset.y= transform.eulerAngles.y;
            reset.x = 0;
            target.eulerAngles = reset;
        }
    }
}
