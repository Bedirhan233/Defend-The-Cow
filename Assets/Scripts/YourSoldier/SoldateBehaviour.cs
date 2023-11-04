using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class SoldateBehaviour : MonoBehaviour
{
    public float Movespeed = 5;

    public float bulletSpeed = 10;
    public float bulletDamage = 10;

    public float range = 5;

    bool tooClose;

    public bool inMoveRange;
    public bool canShoot;

    public Image greenBar;
    public Image redBar;

    public float healthDamage = 5;
    float damageDivided;
    float redBarValue;


    Vector3 velocity;

    Vector2 direction;

    GameObject target;

    public GameObject bullet;
    public GameObject shotOutHole;

    public Bullet bulletScript;

    public float shootingRange = 10;
    public float movingRange = 20;

    float timer;
    public float fireRate;

    public GameObject blood;

    Vector2 randomPosition;



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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Soldat blir skjuten");
            Instantiate(blood, transform.position, transform.rotation);
            //HealthToUi();
        }
    }


    void HealthToUi(int damage)
    {
        damageDivided = damage / 100;
        redBarValue += damageDivided;
        redBar.fillAmount = redBarValue;
        if (redBarValue >= 1)
        {
            Destroy(gameObject);
        }
    }
}
