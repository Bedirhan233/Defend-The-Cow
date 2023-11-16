using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn1;

    public GameObject soldier;

    public GameManager manager;

    Vector2 mousePos;

    public int MaxEnemySpawnFromCar = 2;
    int EnemySpawnFromCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       

        
    }

    public void SpawnEnemyFromCar()
    {
        if(EnemySpawnFromCar < MaxEnemySpawnFromCar)
        {
        Instantiate(enemy, spawn1.transform);
        EnemySpawnFromCar++;
        }
    }
}
