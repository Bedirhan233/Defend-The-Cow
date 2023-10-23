using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldateBehaviour : MonoBehaviour
{
    public float speed = 5;

    public float range = 5;

    bool tooClose;

    

    Vector3 velocity;

    Vector2 direction;

    public Transform target;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Enemy").transform;

        direction = target.transform.position - transform.position;
        transform.up = direction;

        if (direction.magnitude < range)
        {
            tooClose = true;
        }

        else
        {
            tooClose = false;
        }
       

        direction.Normalize();
        velocity = direction * speed * Time.deltaTime;


        

        transform.position += velocity;

        if( tooClose ) 
        {
            velocity = Vector2.zero;
        }
 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
}
