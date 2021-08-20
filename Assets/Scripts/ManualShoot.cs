using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualShoot : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float speedRotation;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject manualBullet;

    private float nextFire;
    Vector3 rotationInput = Vector3.zero;
    
    void Update()
    {
        Look();
        Shoot();
    }

    void Look()
    {
        if(GameManager.GM.isFPSCamera)
        {
            rotationInput.x = Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime;
            rotationInput.y = Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;

            transform.Rotate(Vector3.up * rotationInput.x);
            transform.Rotate(Vector3.right * rotationInput.y);
        }   
    }

    void Shoot()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(manualBullet, shootPosition.position, shootPosition.rotation);
        }
    }
}
