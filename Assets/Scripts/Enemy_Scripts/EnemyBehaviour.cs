using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    Rigidbody2D rb2;
    Enemy_Range enemyRange;
    GameObject currentTarget;

    Vector2 direction;
    
    float timer;
    
    bool isIdle = false;


    [Header("UI")]
    public Image greenBar;
    public Image redBar;
    public float uiGreenBar;
    public float fill = 1;

    [Header("Animation")]
    public Animator animator;
    public bool isWalkingAnimation;

    [Header("GameObjects")]
    public GameObject bullet;
    public GameObject shotOutHole;
    public GameObject blood;
    public Bullet bulletScript;

    [Header("Range")]
    public float MoveRange = 5;
    public float shootingRange = 30f;
    public bool isInMoveRange;

    [Header("Character Move")]
    public float startToIdle = 30;
    public float moveSpeed = 2;

    [Header("Shooting")]
    public float fireRate = 5;
    public float shootingDamage = 10;
    public float shootingSpeed = 5;
    public bool shooting;

    [Header("Health")]
    public float health = 100;
    public float healthDamage = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        enemyRange = GetComponentInChildren<Enemy_Range>();
        bulletScript.damage = shootingDamage;
        bulletScript.speed = shootingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
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
            rb2.velocity = moveSpeed * direction;
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
