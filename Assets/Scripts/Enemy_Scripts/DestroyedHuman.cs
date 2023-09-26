using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedHuman : MonoBehaviour
{

    public GameObject head;
    public GameObject arm;
    public GameObject body;
    public GameObject leg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeBodies()
    {
        Instantiate(head, transform.position, transform.rotation);
        Instantiate(arm, transform.position, transform.rotation);
        Instantiate(body, transform.position, transform.rotation);
        Instantiate(leg, transform.position, transform.rotation);
    }
}
