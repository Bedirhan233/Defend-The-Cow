using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject OutHoleLeft;
    public GameObject OutHoleRight;
    public GameObject bullet;
    public GameObject weapon;
    float timer;
    public float fireRate = 2;

    public EnemyBehaviour enemyBehaviour;


    SpriteRenderer WeaponspriteRenderer;
    SpriteRenderer playerSprite;
    public GameObject player;
    bool Weaponflip = false;

    public int totalAmmo = 20;
    int currentAmmo;

    bool weaponIsReloaded;



    // Start is called before the first frame update
    void Start()
    {
        WeaponspriteRenderer = weapon.GetComponent<SpriteRenderer>();
        currentAmmo = totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0)
        {
            weaponIsReloaded = true;
        }
        else
            weaponIsReloaded = false;    
        Flip();

        

    }

    private void Flip()
    {
        WeaponspriteRenderer.flipY = Weaponflip;

        if (Input.mousePosition.x < 950)
        {

            Weaponflip = true;
            
            Shoot(OutHoleRight, bullet);
            
        }
        else
        {
            Weaponflip = false;

            
                Shoot(OutHoleLeft, bullet);
            
            
        }
    }

    private void Shoot(GameObject OutHole, GameObject bullet)
    {
        

        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = direction;

        

     

        if ((Input.GetMouseButton(0) && timer > fireRate) && weaponIsReloaded)
        {
            currentAmmo--;
            Debug.Log(currentAmmo);
            Instantiate(bullet, OutHole.transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
