using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn1;

    public int MaxEnemySpawnFromCar = 2;
    int EnemySpawnFromCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
