using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceExplosion : MonoBehaviour
{

    Rigidbody2D rb;
    float axisX;
    float axisY;
    float torque;
    // Start is called before the first frame update
    void Start()
    {
        axisX = Random.Range(-10, 10);
        axisY = Random.Range(-10, 10);
        torque = Random.Range(-10, 10);
        rb = GetComponent<Rigidbody2D>(); 

        rb.AddForce(new Vector2 (axisX, axisY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
}
