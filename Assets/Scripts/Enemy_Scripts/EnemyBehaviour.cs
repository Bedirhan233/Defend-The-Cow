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


        target = FindAnyObjectByType<SimpleMovePlayer>().transform;

        enemyIsWalkingToPlayer = true;




    }

    // Update is called once per frame
    void Update()
    {

        direction = target.position - transform.position;

        


        

        MoveToThePlayer();

        ShootingAnimation();

    }

    void MoveToThePlayer()
    {

        direction = target.position - transform.position;
        direction.Normalize();
        transform.up = direction;

        if (enemyIsWalkingToPlayer)
        {
            isIdle = false;
            animator.SetBool("Walk", true);


            // turn thhead to the player

            Debug.Log("De kommer in!!");

            transform.up = target.transform.position;

            //calculate distance to the player

            direction = target.position - transform.position;

            direction.Normalize();


            rb2.velocity = speed * direction;
        }

        Debug.Log("Sqr magnitude " + direction.sqrMagnitude);
        if (direction.sqrMagnitude < startToIdle)
        {
            isIdle = true;
            enemyIsWalkingToPlayer = false;
            animator.SetBool("Walk", false);

            if (isIdle)
            {

                rb2.velocity *= 0;
                isIdle = false;
            }
        }
        else
        {
            isIdle = false;
            enemyIsWalkingToPlayer = true;
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
