using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{

    bool playerFlip;
    SpriteRenderer WeaponspriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        WeaponspriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        WeaponspriteRenderer.flipX = playerFlip;

        
        

        if (Input.mousePosition.x < 950)
        {
            
            
            playerFlip = false;
            
        }
        else
        {
           
            playerFlip = true;
            
        }

    }
}
