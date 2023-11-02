using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Default")
        {
            Destroy(gameObject);    
        }

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Soldier")
        {
            Destroy(gameObject);
        }
    }
}
