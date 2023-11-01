using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldateBehaviour : MonoBehaviour
{
    public float speed = 5;

    public float range = 5;

    bool tooClose;

    public bool inMoveRange;
    public bool canShoot;

    Vector3 velocity;

    Vector2 direction;

    GameObject target;

    public GameObject bullet;
    public GameObject shotOutHole;

    public float shootingRange = 10;
    public float movingRange = 20;

    float timer;
    public float fireRate;

    Vector2 randomPosition;



    // Start is called before the first frame update
    void Start()
    {
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

            Debug.Log(target);
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
                velocity = direction * speed * Time.deltaTime;
                transform.position += velocity;

            }
        

            
            
        


        


        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
}
