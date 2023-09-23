using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : MonoBehaviour
{

    public EnemyBehaviour enemyBehaviour;
    public float ShootRange;

    bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.parent.name);

        transform.localScale = new Vector2(ShootRange, ShootRange);
        if (isShooting )
        {
            enemyBehaviour.Shoot();
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            isShooting = true;

        }     
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isShooting = false;
            enemyBehaviour.shooting = false;
        }
        
    }

}
