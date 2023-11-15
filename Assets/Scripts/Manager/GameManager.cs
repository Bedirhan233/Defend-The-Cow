using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int newAmmo = 1;
    public int ammoCost = 2;

    public int soldierCost;
    public Weapon weapon;
    public int currentMoney;
    public int moneyFromEnemy = 2;

    GameObject[] soldier;

    public bool enoughMoneyForSoldier = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        soldier = GameObject.FindGameObjectsWithTag("Soldier");
    }

    public void BuyNewAmmo()
    {
        if(ammoCost <= currentMoney) 
        {
        weapon.currentAmmo += newAmmo;
            currentMoney -= ammoCost;
        
        }
        
    }



    public void GetCoinsFromEnemy()
    {
        currentMoney += moneyFromEnemy;
    }

    public void BuySoldier()
    {
        if (soldierCost <= currentMoney)
        {
            enoughMoneyForSoldier = true;

        }

    }
}
