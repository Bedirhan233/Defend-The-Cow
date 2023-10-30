using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour;

    SpriteRenderer spriteRenderer;

    bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        transform.localScale = new Vector3(enemyBehaviour.shootingRange, enemyBehaviour.shootingRange);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            enemyBehaviour.shooting = true;

        }     
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyBehaviour.shooting = false;

        }

    }

}
