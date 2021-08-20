using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    private Rigidbody rigidbodyBullet;

    void Awake()
    {
        rigidbodyBullet = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Movement();
    }

    void Movement()
    {
        rigidbodyBullet.velocity = transform.forward * speedBullet;
    }
}
