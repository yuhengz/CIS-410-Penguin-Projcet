using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        nav.speed = 17.0f;
    }

    // Update is called once per frame
    void Update()
    {
        nav.enabled = true;
        nav.SetDestination(player.position);
    }
}
