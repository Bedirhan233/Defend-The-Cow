using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedHuman : MonoBehaviour
{

    public GameObject head;
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject body;
    public GameObject body2;
    public GameObject leftLeg;
    public GameObject rightLeg;
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
        Instantiate(rightArm, transform.position, transform.rotation);
        Instantiate(leftArm, transform.position, transform.rotation);
        Instantiate(body, transform.position, transform.rotation);
        Instantiate(rightLeg, transform.position, transform.rotation);
        Instantiate(leftLeg, transform.position, transform.rotation);
    }
}
