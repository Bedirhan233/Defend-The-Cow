using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI ammoUi;
    public TextMeshProUGUI soldierCountUi;

    public Weapon weapon;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "Coins " + gameManager.currentMoney;
        ammoUi.text = "total ammo " + weapon.currentAmmo;
        soldierCountUi.text = "total soldier " + gameManager.soldier.Length;
    }
}
