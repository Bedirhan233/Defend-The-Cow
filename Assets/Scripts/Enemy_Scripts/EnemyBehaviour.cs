using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Transform target;
    public GameObject bullet;
    public GameObject shotOutHole;

    public GameObject blood;

    

    

    public Animator animator;

    Rigidbody2D rb2;

    public float speed = 2;

    public bool shooting = false;
    public float MoveRange = 5;
    public float fireRate = 5;
    float timer;

    bool isIdle = false;

    bool enemyIsWalkingToPlayer;

    public float startToIdle = 30;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2 = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();



        enemyIsWalkingToPlayer = true;




    }

    // Update is called once per frame
    void Update()
    {
        target = FindAnyObjectByType<SimpleMovePlayer>().transform;
        MoveToThePlayer();

        ShootingAnimation();

    }

    void MoveToThePlayer()
    {

        direction = target.position - transform.position;


        //if (enemyIsWalkingToPlayer)
        //{
        //    isIdle = false;
        //    animator.SetBool("Walk", true);

        //}

        if (direction.sqrMagnitude < startToIdle)
        {
            //isIdle = true;
            //enemyIsWalkingToPlayer = false;
            //animator.SetBool("Walk", false);

            
                rb2.velocity = Vector2.zero;
                isIdle = true;
            
        transform.up = direction;
        }
        else
        {
            isIdle = false;
            //enemyIsWalkingToPlayer = true;
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


        }
        else
        {
            animator.SetBool("ShootingAnimation", false);
            shooting = false;

        }
    }

    public void Shoot()
    {

        if(fireRate < timer)
        {
        shooting = true;
        Instantiate(bullet, shotOutHole.transform.position, transform.rotation);
        timer = 0;
           

        }
        
        timer += Time.deltaTime;

        Debug.Log("SHooting");
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
        }
    }




}
