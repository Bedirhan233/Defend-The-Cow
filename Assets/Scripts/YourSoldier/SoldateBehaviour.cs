using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldateBehaviour : MonoBehaviour
{
    public float speed = 5;

    public float range = 5;

    

    Vector3 velocity;

    Vector2 direction;

    public Transform target;

   
    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {


        
            direction = target.transform.position - transform.position;


            transform.up = direction;

            direction.Normalize();

            if(direction.sqrMagnitude < range ) 
            {
            velocity = Vector2.zero;
            }

            velocity = direction * speed * Time.deltaTime;

            transform.position += velocity;
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
}
