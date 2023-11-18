using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class SoldateBehaviour : MonoBehaviour
{
    Vector3 velocity;
    Vector2 direction;

    Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

    GameObject target;

    bool tooClose;
    float timer;
    float timerForRandom;

    [Header ("UI")]
    public Image greenBar;
    public Image redBar;


    [Header("GameObject")]
    public GameObject bullet;
    public GameObject shotOutHole;
    public Bullet bulletScript;
    public GameObject blood;

    [Header("Move settings and range")]
    public bool canShoot;
    public bool inMoveRange;
    public float startToIdle = 5;
    public float shootingRange = 10;
    public float movingRange = 20;
    public float Movespeed = 5;
    public float walkPointRange = 5;

    [Header("Health")]
    public float health = 100;


    [Header("Bullet")]
    public float bulletSpeed = 10;
    public float bulletDamage = 10;
    public float fireRate;

    Vector2 walkPoint;

    


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        bulletScript.speed = bulletSpeed;
        bulletScript.damage = bulletDamage;

        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        FindAndMoveToEnemy();

        

    }


    private void FindAndMoveToEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        direction = target.transform.position - transform.position;
        direction.Normalize();

        RaycastHit2D inIdleRange;
        inIdleRange = Physics2D.Raycast(transform.position, direction, startToIdle);
        Debug.DrawRay(transform.position, direction * startToIdle, Color.blue);

        RaycastHit2D inMoveRange;
        inMoveRange = Physics2D.Raycast(transform.position, direction, movingRange);
        Debug.DrawRay(transform.position, direction * movingRange, Color.yellow);

        RaycastHit2D inShootingRange = Physics2D.Raycast(transform.position, direction, shootingRange);
        Debug.DrawRay(transform.position, direction * shootingRange, Color.red);

        if (inShootingRange)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        ShootingProcess();
        if (inIdleRange)
        {
            tooClose = true;
        }
        else
        {
            tooClose = false;
        }


        if (tooClose)
        {
            velocity = Vector2.zero;
            transform.up = direction;
        }
        if (!tooClose && inMoveRange)
        {
            Debug.Log("In move range");
            transform.up = direction;
            velocity = direction * Movespeed * Time.deltaTime;
            transform.position += velocity;

        }
        Debug.Log("Time: " + timerForRandom);
        if (!inShootingRange && !inMoveRange)
        {
            timerForRandom -= Time.deltaTime;

            if (timerForRandom < 0)
            {
                RandomDirection();
            }
        }
            
        


    }

    private void RandomDirection()
    {
        
        
            Debug.Log("Random IDle");
            var oldDir = direction;
            do
            {
                direction = dirs[Random.Range(0, dirs.Length)];
            }
            while (direction == oldDir);

            velocity = direction * Movespeed * Time.deltaTime;
            transform.position += velocity;


        timerForRandom = Random.Range(0.5f, 2);
    }

    private void ShootingProcess()
    {
        

        

        if (canShoot)
        {
            if (fireRate < timer)
            {
                Instantiate(bullet, shotOutHole.transform.position, transform.rotation);
                timer = 0;


            }

            timer += Time.deltaTime;

        }
    }
   

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        Bullet soldateBullet;
        soldateBullet = other.gameObject.GetComponent<Bullet>();
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(blood, transform.position, transform.rotation);
            health = health - soldateBullet.damage;
            HealthToUi();
        }
    }


    void HealthToUi()
    {
        float healthDecimal;
        healthDecimal = health / 100;

        greenBar.fillAmount = healthDecimal;
        if (healthDecimal <= 0)
        {
            Destroy(gameObject);
        }
    }
}
