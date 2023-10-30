using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    SoldateBehaviour soldier;

    
    void Start()
    {
        soldier = GetComponentInParent<SoldateBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(soldier.shootingRange, soldier.shootingRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Can shoot");
            soldier.canShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            soldier.canShoot = false;
        }
    }

}
