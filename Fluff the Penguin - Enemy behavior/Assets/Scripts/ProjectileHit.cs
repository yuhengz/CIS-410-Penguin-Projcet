using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public LayerMask EnemyMask;
    public static int damage = 1;
    public float MaxLifeTime = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, EnemyMask);

        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRB = colliders[i].GetComponent<Rigidbody>();

            if (!targetRB)
                continue;

            EnemyHealth targetHP = targetRB.GetComponent<EnemyHealth>();

            if (!targetHP)
                continue;

            targetHP.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
