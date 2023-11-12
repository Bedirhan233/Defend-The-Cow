using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalEnemyPlayerHave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(totalEnemyPlayerHave);
    }

    public void BuyNewAmmo()
    {
        Weapon.newAmmo++;
    }
}
