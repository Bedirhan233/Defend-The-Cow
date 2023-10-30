using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldateRange : MonoBehaviour
{
    SoldateBehaviour soldier;
    
    void Start()
    {
        soldier = GetComponentInParent<SoldateBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(soldier.movingRange, soldier.movingRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            soldier.inMoveRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            soldier.inMoveRange = false;
        }
    }

    
}
