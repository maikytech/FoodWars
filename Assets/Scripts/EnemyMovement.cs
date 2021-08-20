using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 dir;

    private void Movement()
    {
        if(gameObject.transform.tag == "redSoldier")
            transform.position = Vector3.MoveTowards(transform.position, GameManager.GM.blueTower.position, GameManager.GM.speedEnemy * Time.deltaTime);

        if(gameObject.transform.tag == "blueSoldier")
            transform.position = Vector3.MoveTowards(transform.position, GameManager.GM.redTower.position, GameManager.GM.speedEnemy * Time.deltaTime);
        
    }

    private void LookAt()
    {
        if(gameObject.transform.tag == "redSoldier")
            dir = GameManager.GM.blueTower.position - transform.position;

        if(gameObject.transform.tag == "blueSoldier")
            dir = GameManager.GM.redTower.position - transform.position;

        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, GameManager.GM.rotationSpeedEnemy * Time.deltaTime);   

    }

    private void Update()
    {
        if(GameManager.GM.isGameOver == false)
        {
            Movement();
            LookAt();
        }
        
    }
}
