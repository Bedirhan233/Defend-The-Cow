using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int newAmmo = 1;
    public int ammoCost = 2;

    public int soldierCost = 5;
    public Weapon weapon;
    public int currentMoney;
    public int moneyFromEnemy = 10;

    public GameObject soldierUi;
    public GameObject soldierPrefab;
    Vector2 cursorPos;

    public GameObject[] soldier;

    public bool enoughMoneyForSoldier = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        ClickToInstantiate();

        soldier = GameObject.FindGameObjectsWithTag("Soldier");

    }

    private void ClickToInstantiate()
    {
        if (enoughMoneyForSoldier)
        {
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            soldier = GameObject.FindGameObjectsWithTag("Soldier");
            soldierUi.transform.position = new Vector2(cursorPos.x, cursorPos.y);
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(soldierPrefab, cursorPos, transform.rotation);
                enoughMoneyForSoldier = false;
            }

        }
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
            currentMoney -= soldierCost;
        }

    }
}
