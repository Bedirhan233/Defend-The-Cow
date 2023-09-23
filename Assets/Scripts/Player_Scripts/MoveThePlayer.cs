using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThePlayer : MonoBehaviour
{

    Vector2 velocity;
    Vector2 direction;
    Vector2 position;
    Rigidbody2D rb2;
    public float accelarate;
    public float deaccelarate;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");



        if(direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        velocity += direction * accelarate * Time.deltaTime;

        if(velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }



        if (direction.sqrMagnitude == 0)
        {
            velocity *= 1 - deaccelarate * Time.deltaTime;
        }

        position += velocity * Time.deltaTime;  
        transform.position = position;
        rb2.velocity = velocity;
    }
}
