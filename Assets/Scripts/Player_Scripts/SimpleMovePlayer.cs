using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class SimpleMovePlayer : MonoBehaviour
{
    Vector2 input;
    Vector3 velocity;
    Vector3 position;

   
    Rigidbody2D rb2;

 

    public GameObject enemy;
    public GameObject player;   

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();  
    
    }

    // Update is called once per frame
    void Update()
    {

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

      
        
        
    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + input * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            // add coins to the system
            GameManager.totalEnemyPlayerHave++;
        }
    }
}
