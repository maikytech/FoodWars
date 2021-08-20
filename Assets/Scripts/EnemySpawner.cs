using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float wavesTime = 10.0f;
    public int numberOfEnemies = 10;

    private void Start()
    {
       InvokeRepeating("EnemyIncrements", wavesTime, wavesTime);
    }

    void EnemyIncrements()
    {
        if (numberOfEnemies < 100)
        {
            AddEnemies(numberOfEnemies);
        }
    }

    void AddEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {

            
            float xValue_1 = Random.Range(-5, 5);
            //float xValue_2 = Random.Range(-10, 10);
            //float xValue_3 = Random.Range(10, 20);
            float zValue = Random.Range(40, 80);

            //float[] positions = { xValue_1, xValue_2, xValue_3 };

            Vector3 spawnPosition = new Vector3(xValue_1, 0.44f, zValue);
            //Vector3 spawnPosition2 = new Vector3(spawnPosition.x + 0.5f, 0.44f, zValue);
            //Vector3 spawnPosition3 = new Vector3(spawnPosition.x + 1f, 0.44f, zValue);

            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            var obj = Instantiate(enemyPrefab, spawnPosition , spawnRotation);
            //var obj2 = Instantiate(enemyPrefab, spawnPosition2, spawnRotation);
            //var obj3 = Instantiate(enemyPrefab, spawnPosition3, spawnRotation);
        }

        //numberOfEnemies += 10;
    }
}
