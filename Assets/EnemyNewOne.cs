using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNewOne : MonoBehaviour
{

    Transform target;
    Vector2 direction;

    Vector2 newPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<MoveThePlayer>().transform;
        newPos = new Vector2(0, 0);

        

        //direction = target.position - transform.position;
        //direction.Normalize();

       // transform.up = target.position;

        transform.LookAt(newPos);   
        
        
        
        
    }
}
