using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animationSource;
    EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>(); 
        animationSource = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimation();
    }

    void WalkingAnimation()
    {
        if (enemyBehaviour.isWalkingAnimation)
        {
            animationSource.SetBool("Walk", true);
            

        }
        if (!enemyBehaviour.isWalkingAnimation)
        {
            animationSource.SetBool("Walk", false);


        }
    }
}
