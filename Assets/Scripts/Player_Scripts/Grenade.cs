using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    float timer;
    bool hasExploded;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        hasExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0 && !hasExploded)
        {
            Explode();
            hasExploded=true;
        }
    }

    private static void Explode()
    {
        Debug.Log("BOM");
    }
}
