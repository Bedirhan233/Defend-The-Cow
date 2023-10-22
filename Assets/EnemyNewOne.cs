using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNewOne : MonoBehaviour
{

    Transform target;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        target = FindObjectOfType<MoveThePlayer>().transform;

        direction = target.position - transform.position;
        direction.Normalize();

       // transform.up = target.position;

        transform.LookAt(direction);   
        
        
    }
}
