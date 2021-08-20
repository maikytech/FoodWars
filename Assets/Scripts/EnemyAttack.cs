using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collision(other);
    }

    private void Collision(Collider other)
    {
        if (other.tag == "redSoldier")
        {
            Debug.Log("Ataque a la torre");
            gameObject.GetComponent<Tower>().TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
