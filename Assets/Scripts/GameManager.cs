using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    [Header("Enemy Setup")]
    public float speedEnemy = 5;
    public float rotationSpeedEnemy = 3;

    [SerializeField] private GameObject redSoldier;
    [SerializeField] private GameObject blueSoldier;
    [SerializeField] private GameObject bigSoldier;

    [Header("Enemy Wave Setup")]

    public Transform blueTower;
    public Transform redTower;
    public bool isGameOver = false;
    public bool isFPSCamera;

    [SerializeField] private int numberOfRedSoldiers;
    [SerializeField] private int numberOfBlueSoldiers;
    [SerializeField] private int score = 0;
    [SerializeField] private float wavesTime;
    [SerializeField] private float startWavesTime;

    [Header("Cameras")]
    public GameObject isometricCamera;
    public GameObject FPSCamera;

    private void Awake()
    {
        if(GM != null && GM != this)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
        GM = this;

        FPSCamera.SetActive(false);
        isGameOver = false;
        isFPSCamera = false;
        //numberOfRedSoldiers = 1;
        score = 0;

    }

    private void Start()
    {
        InvokeRepeating("SoldiersIncrements", startWavesTime, wavesTime);
        AddBigs();
    }

    void SoldiersIncrements()
    {
        if (numberOfRedSoldiers < 100 && isGameOver == false)
        {
            AddRedSoldiers(numberOfRedSoldiers);
            AddBlueSoldiers(numberOfBlueSoldiers);
        }
    }

    void AddRedSoldiers(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float xValue_1 = Random.Range(-10, 0);
            float xValue_2 = Random.Range(0, 10);
            float zValue = Random.Range(40, 80);

            float[] positions = { xValue_1, xValue_2};

            Vector3 spawnPosition = new Vector3(positions[Random.Range(0, 2)], 0.44f, zValue);
            Vector3 spawnPosition2 = new Vector3(spawnPosition.x + 2f, 0.44f, zValue);
            Vector3 spawnPosition3 = new Vector3(spawnPosition.x + 4f, 0.44f, zValue);

            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            var obj = Instantiate(redSoldier, spawnPosition, spawnRotation);
            var obj2 = Instantiate(redSoldier, spawnPosition2, spawnRotation);
            var obj3 = Instantiate(redSoldier, spawnPosition3, spawnRotation);
        }

        //numberOfEnemies += 10;
    }

    void AddBlueSoldiers(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float xValue_1 = Random.Range(-10, 0);
            float xValue_2 = Random.Range(0, 10);
            float zValue = Random.Range(-20, 0);

            float[] positions = { xValue_1, xValue_2};

            Vector3 spawnPosition = new Vector3(positions[Random.Range(0, 2)], 0.44f, zValue);
            Vector3 spawnPosition2 = new Vector3(spawnPosition.x + 2f, 0.44f, zValue);
            Vector3 spawnPosition3 = new Vector3(spawnPosition.x + 4f, 0.44f, zValue);

            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            var obj = Instantiate(blueSoldier, spawnPosition, spawnRotation);
            var obj2 = Instantiate(blueSoldier, spawnPosition2, spawnRotation);
            var obj3 = Instantiate(blueSoldier, spawnPosition3, spawnRotation);
        }

        //numberOfEnemies += 10;
    }

    void AddBigs() {

        Vector3 position = new Vector3(-10f, 2.5f, 80f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(bigSoldier, position, rotation);
    }

    public void Score()
    {
        score++;
        UIManager.UpdateScore(score);
        
        if(score <= 0)
        {
            isGameOver = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
