using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{

    public GameObject greande;

    public float speed = 5;

    public float throwForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) 
        {

            Throw();
        }
    }

    void Throw()
    {
        Instantiate(greande, transform.position, transform.rotation);
        
    }
}
