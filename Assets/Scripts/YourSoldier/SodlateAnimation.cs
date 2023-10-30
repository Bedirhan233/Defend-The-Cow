using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodlateAnimation : MonoBehaviour
{
    Animator animator;
    SoldateBehaviour soldate;
    // Start is called before the first frame update
    void Start()
    {
        soldate = GetComponentInParent<SoldateBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(soldate.inMoveRange == true)
        {
            animator.SetBool("isWalking", true);
        }

        if (soldate.inMoveRange == false)
        {
            animator.SetBool("isWalking", false);
        }

        
    }
}
