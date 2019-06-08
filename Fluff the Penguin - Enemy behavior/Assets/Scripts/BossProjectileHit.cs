using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileHit : MonoBehaviour
{
    public LayerMask PlayerMask;
    public static int damage = 20;
    public float MaxLifeTime = 2f;
    AudioSource hit;
    // Start is called before the first frame update
    private void Start()
    {
        hit = GetComponent<AudioSource>();
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, PlayerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRB = colliders[i].GetComponent<Rigidbody>();

            if (!targetRB)
                continue;

            PenguinHealth targetHP = targetRB.GetComponent<PenguinHealth>();

            if (!targetHP)
                continue;
            
            targetHP.TakeDamage(damage);
            hit.Play();

            Destroy(gameObject,0.01f);
        }
    }
}
