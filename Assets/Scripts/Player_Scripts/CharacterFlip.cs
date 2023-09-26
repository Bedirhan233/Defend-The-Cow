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
        Debug.Log(Input.mousePosition);
        WeaponspriteRenderer.flipX = playerFlip;

        Debug.Log(Input.mousePosition.x);
        

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
