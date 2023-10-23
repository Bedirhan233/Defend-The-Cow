using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNewOne : MonoBehaviour
{
    public float speed = 10;
    Transform target;
    Vector2 direction;

    Rigidbody2D rb2d;

    Vector2 newPos;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<MoveThePlayer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        direction =   target.position - transform.position;

        direction.Normalize();


        rb2d.velocity = direction * speed;  
        
        Debug.Log(rb2d.velocity);
        
        
    }
}
