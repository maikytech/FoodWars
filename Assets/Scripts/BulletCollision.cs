using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collision(other);
    }

    private void Collision(Collider other)
    {
        if (other.tag == "redSoldier")
        {
            GameManager.GM.Score();
            Destroy(other.gameObject);
            Destroy(gameObject);
           
        }

    }
}
