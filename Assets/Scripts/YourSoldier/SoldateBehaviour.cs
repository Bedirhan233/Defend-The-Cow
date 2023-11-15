using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class SoldateBehaviour : MonoBehaviour
{
    Vector3 velocity;
    Vector2 direction;

    GameObject target;

    bool tooClose;
    float timer;

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
    public float range = 5;
    public float shootingRange = 10;
    public float movingRange = 20;
    public float Movespeed = 5;

    [Header("Health")]
    public float health = 100;


    [Header("Bullet")]
    public float bulletSpeed = 10;
    public float bulletDamage = 10;
    public float fireRate;


    // Start is called before the first frame update
    void Start()
    {
        bulletScript.speed = bulletSpeed;
        bulletScript.damage = bulletDamage;

        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        FindAndMoveToEnemy();

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

    private void FindAndMoveToEnemy()
    {

            target = GameObject.FindGameObjectWithTag("Enemy");

            if(target == null)
            {
            target = GameObject.FindGameObjectWithTag("Idle");
            }
            

            direction = target.transform.position - transform.position;

            if (direction.sqrMagnitude < range)
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
            }
            if (!tooClose && inMoveRange)
            {

                direction.Normalize();
                transform.up = direction;
                velocity = direction * Movespeed * Time.deltaTime;
                transform.position += velocity;

            }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
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
