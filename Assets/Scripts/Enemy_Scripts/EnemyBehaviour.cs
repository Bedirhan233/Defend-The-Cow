using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;
    public GameObject shotOutHole;

    

    public Animator animator;

    Rigidbody2D rb2;

    public float speed = 2;

    public bool shooting = false;
    public float MoveRange = 5;
    public float fireRate = 5;
    float timer;

    public float startToIdle = 30;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2 = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        
        if(shooting)
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

    void MoveToPlayer()
    {
        

        if (direction.sqrMagnitude < MoveRange)
        {

            animator.SetBool("Walk", true);

            // turn thhead to the player

            transform.up = target.transform.position;

            //calculate distance to the player

            direction = target.position - transform.position;

            if(direction.sqrMagnitude < startToIdle) 
            {
                rb2.velocity *= 0;
            }
            else
            {
                direction.Normalize();

                rb2.velocity = speed * direction;
            }
            
        }

        
        

        
    }

    
}
