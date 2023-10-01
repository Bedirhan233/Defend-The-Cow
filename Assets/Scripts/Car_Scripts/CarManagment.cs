using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarManagment : MonoBehaviour
{
    public Transform carBorn;
    public Transform target;

    public SpawnEnemy spawnEnemy;

    public GameObject car;

    Vector2 direction;
    Vector3 velocity;

    bool hasReached = false;

    

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
          
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnEnemy);
        //Instantiate(car, carBorn.transform.position, carBorn.transform.rotation);

        if(!hasReached)
        {
        MovingCar();

        }

        if (direction.x <= 0 && direction.y < 0)
        {
            
            hasReached = true;  
            spawnEnemy.SpawnEnemyFromCar();
            velocity = Vector3.zero;
        }
    }

    private void MovingCar()
    {
        direction = target.transform.position - transform.position;


        direction.Normalize();

        velocity = direction * speed * Time.deltaTime;

        transform.position += velocity;
    }
}
