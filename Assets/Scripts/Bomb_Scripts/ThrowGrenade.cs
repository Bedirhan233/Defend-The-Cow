using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{

    public GameObject grenade;
    public GameObject grenadeOut;

    Vector2 mouse;
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
        var newGranade = Instantiate(grenade, grenadeOut.transform.position, grenadeOut.transform.rotation);

        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(grenadeOut.transform.position);
        grenadeOut.transform.up = direction;



        newGranade.GetComponent<Grenade>().player = gameObject.transform.position;

    }
   


}
