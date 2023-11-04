using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject target;
    GameObject soldierTarget;

    GameObject currentTarget;

    Transform soldier;
    Transform player;
    public GameObject bullet;
    public GameObject shotOutHole;

    public GameObject blood;

    Enemy_Range enemyRange;

    public float health = 100;

    public Image greenBar;
    public Image redBar;


    public Animator animator;

    Rigidbody2D rb2;

    public float uiGreenBar;

    

    public float speed = 2;

    public bool shooting;
    public float MoveRange = 5;
    public float fireRate = 5;
    float timer;

    public float shootingRange = 30f;

    bool isIdle = false;

    public float healthDamage = 15;


    public float startToIdle = 30;

    public bool isInMoveRange;

    public float fill = 1;

    public bool isWalkingAnimation;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2 = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        enemyRange = GetComponentInChildren<Enemy_Range>();



       



    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(currentTarget);

        MoveToThePlayer();

        ShootingAnimation();

    }

    void MoveToThePlayer()
    {
        currentTarget = GameObject.FindGameObjectWithTag("Soldier");

        if (currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Player");
        }



        direction = currentTarget.transform.position - transform.position;

        if (direction.sqrMagnitude < startToIdle)
        {
                rb2.velocity = Vector2.zero;
                isIdle = true;
            
                transform.up = direction;
            isWalkingAnimation = false;

        }
        else
        {
            isIdle = false;
            isWalkingAnimation = true;
        }

        if(!isIdle)
        {
            direction.Normalize();
            transform.up = direction;
            rb2.velocity = speed * direction;
        }
        
    }

    private void ShootingAnimation()
    {
        if (shooting)
        {
            animator.SetBool("ShootingAnimation", true);
            Shoot();

        }
        if (!shooting)
        {
            animator.SetBool("ShootingAnimation", false);
           

        }
    }

    void Shoot()
    {

        if(fireRate < timer)
        {
        Instantiate(bullet, shotOutHole.transform.position, transform.rotation);
        timer = 0;
           

        }
        
        timer += Time.deltaTime;

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MoveRange);

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Bullet soldateBullet;
        soldateBullet = other.gameObject.GetComponent<Bullet>();
        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(blood, transform.position, transform.rotation);
            health = health - soldateBullet.damage;
        }

        HealthToUi();
        Debug.Log(uiGreenBar);
    }

    private void HealthToUi()
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
