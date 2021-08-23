using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Tower2 : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField]private float triggerRange;
    [SerializeField] private float closeTriggerRange;
    [SerializeField] private float timeToShoot;
    [SerializeField] private bool stopShoot;
    [SerializeField] private Transform rotationPart;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Enemy currentTarget;
    [SerializeField] private Bullet bullet;
    [SerializeField] private List<Enemy> currentTargets = new List<Enemy>();
    [SerializeField] private List<BigEnemy> closeTargets = new List<BigEnemy>();
    [SerializeField] private GameObject bigTarget;

    [Header("Life")]
    [SerializeField] private Image fillLifeImage;
    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife;
    [SerializeField] private bool isDead;

    private void Awake()
    {
        isDead = false;
    }
    private void Start()
    {
        currentLife = maxLife;
        StartCoroutine(AutoShootTimer());
        stopShoot = false;
    }
    private void Update()
    {
        if(GameManager.GM.isGameOver == false)
        {
            EnemyDetection();
            LookRotation();
        }
    }

    private void EnemyDetection()
    {
        //List of enemies that exceeded firing range
        currentTargets = Physics.OverlapSphere(transform.position, triggerRange).
        Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).
        Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).ToList();

        closeTargets = Physics.OverlapSphere(transform.position, closeTriggerRange).
        Where(currentEnemy => currentEnemy.GetComponent<BigEnemy>()).
        Select(currentEnemy => currentEnemy.GetComponent<BigEnemy>()).ToList();

        if (currentTargets.Count > 0)
        {
            currentTarget = currentTargets[0]; 
        }
            
        else if (currentTargets.Count == 0)
        {
            currentTarget = null;
        }

        //Active FPS View
        if (closeTargets.Count > 0)
        {
            stopShoot = true;
            GameManager.GM.FPSCamera.SetActive(true);
            GameManager.GM.isometricCamera.SetActive(false);
            GameManager.GM.isFPSCamera = true;
            Debug.Log("Activa FPS View");
        }
    }
    private void LookRotation()
    {
        if(currentTarget && stopShoot == false)
        {
           rotationPart.LookAt(currentTarget.transform);
        }
    }

    private void AutoShoot()
    {
        if(isDead == false && stopShoot == false)
        {
            var bulletGo = Instantiate(bullet, shootPosition.position, shootPosition.rotation);
            bulletGo.setBullet(currentTarget);
        }
        
    }

    private IEnumerator AutoShootTimer()
    {
        while(true)
        {
            if(currentTarget)
            {
                AutoShoot();
                yield return new WaitForSeconds(timeToShoot);
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(transform.position, triggerRange);
    }

    public void TakeDamage(float damage)
    {
        var newLife = currentLife - damage;
        if (isDead)
            return;

        if(newLife <= 0)
        {
            OnDead();
        }
        currentLife = newLife;

        var fillvalue = currentLife * 1 / 50;
        fillLifeImage.fillAmount = fillvalue;
    }

    private void OnDead()
    {
        isDead = true;
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        GameManager.GM.isGameOver = true;
        UIManager.uiManager.gameOver.SetActive(true);
        UIManager.uiManager.restart.SetActive(true);
        UIManager.uiManager.menu.SetActive(true);
    }
}
