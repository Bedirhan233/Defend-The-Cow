using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldateBehaviour : MonoBehaviour
{
    public float speed = 5;

    

    Vector3 velocity;

    Vector2 direction;

    public Transform target;

    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            direction = target.transform.position - transform.position;

            direction.Normalize();

            velocity = direction * speed * Time.deltaTime;

            transform.position += velocity;

        }
        
    }
}
