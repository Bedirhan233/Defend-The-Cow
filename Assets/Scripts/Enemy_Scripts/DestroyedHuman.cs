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

    public GameObject blood;
    public GameObject blood2;   
    public GameObject blood3;   
    
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

        Instantiate(blood, transform.position, transform.rotation);
        Instantiate(blood2, transform.position, transform.rotation);
        Instantiate(blood3, transform.position, transform.rotation);
    }
}
