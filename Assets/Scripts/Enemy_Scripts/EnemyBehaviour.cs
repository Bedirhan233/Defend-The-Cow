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

    bool isIdle = false;

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
        MoveToThePlayer();

        ShootingAnimation();

    }

    void MoveToThePlayer()
    {

        if (direction.sqrMagnitude < MoveRange)
        {

            animator.SetBool("Walk", true);

            // turn thhead to the player

            transform.up = target.transform.position;

            //calculate distance to the player

            direction = target.position - transform.position;
            Debug.Log(direction.sqrMagnitude);

            if (direction.sqrMagnitude < startToIdle)
            {

                isIdle = true;
                if (isIdle)
                {
                    rb2.velocity *= 0;
                    isIdle = false;
                }
            }
            if (direction.sqrMagnitude > startToIdle)
            {
                direction.Normalize();

                rb2.velocity = speed * direction;

            }
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
            
        }
    }




}
