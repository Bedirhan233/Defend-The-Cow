using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRange : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        transform.localScale = new Vector3(enemyBehaviour.MoveRange, enemyBehaviour.MoveRange);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            enemyBehaviour.isInMoveRange = true;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyBehaviour.isInMoveRange = false;

        }

    }
}
