using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    Transform target;
    Transform soldierTarget;

    Transform currentTarget;
    public GameObject bullet;
    public GameObject shotOutHole;

    public GameObject blood;

    Enemy_Range enemyRange;

    

    public Image greenBar;
    public Image redBar;


    public Animator animator;

    Rigidbody2D rb2;

    public float uiRedBar;

    float transformToUi;

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
        soldierTarget = GameObject.FindWithTag("Enemy").transform;



       



    }

    // Update is called once per frame
    void Update()
    {
        target = FindAnyObjectByType<SimpleMovePlayer>().transform;
        soldierTarget = FindAnyObjectByType<SoldateBehaviour>().transform;

        MoveToThePlayer();

        ShootingAnimation();

    }

    void MoveToThePlayer()
    {
        currentTarget = soldierTarget.transform;
        
        //if(currentTarget == null)
        //{
        //    currentTarget = target;
        //}
        direction = currentTarget.position - transform.position;

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
        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(blood, transform.position, transform.rotation);
            HealthToUi();
        }
    }

    private void HealthToUi()
    {
        transformToUi = healthDamage / 100;
        uiRedBar += transformToUi;
        redBar.fillAmount = uiRedBar;
        if (uiRedBar >= 1)
        {
            Destroy(gameObject);
        }
    }





}
