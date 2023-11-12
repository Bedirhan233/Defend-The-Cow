using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI ammoUi;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "Coins " + GameManager.totalEnemyPlayerHave;
        ammoUi.text = "total ammo " + Weapon.newAmmo;
    }
}
