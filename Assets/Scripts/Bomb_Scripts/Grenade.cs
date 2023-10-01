

using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float bombCountDown = 3;
    public float explosionStrength = 5;
    public float explosionSize = 4;
    public float grenadeSpeed = 20;
    public float deacaleretion;


    public Vector3 mousePos;
    Vector3 velocity;
    Vector3 mouseForc;

    public int throwForce = 20;
    

    

    public GameObject explosionEffect;

    bool hasExploded;
    float timer;

    public Vector3 player;

    // Start is called before the first frame update
    void Start()
    {
        timer = bombCountDown;
        hasExploded = false;

        GameObject player = FindObjectOfType<MoveThePlayer>().gameObject;
        


       
    }

    // Update is called once per frame
    void Update()
    {
        MovingGrenade();
        timer -= Time.deltaTime;

        if (timer <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        
    }

    private void MovingGrenade()
    {


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        mouseForc = player - mousePos;




        deacaleretion = deacaleretion - 0.01f;

        if(deacaleretion < 0)
        {
            deacaleretion = 0;
        }



        Debug.Log(mouseForc.sqrMagnitude);
        grenadeSpeed = grenadeSpeed + mouseForc.magnitude / throwForce;



        
        transform.position += transform.up * grenadeSpeed * deacaleretion * Time.deltaTime;

        




    }

    void Explode()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionSize);    
        GameObject explosionEffectPreFab = Instantiate(explosionEffect, transform.position, transform.rotation);
        
        {
            
        }
        foreach (Collider2D nearbyObjects in colliders)
        {
    
            Rigidbody2D rb = nearbyObjects.GetComponent<Rigidbody2D>();

            

            if (rb != null )
            {
                Vector2 direction = nearbyObjects.transform.position - transform.position;
                direction.Normalize();
                rb.AddForce(direction * explosionStrength);
                
                Destroy(nearbyObjects.gameObject, 0.1f);
            }

            DestroyedHuman destroyed = nearbyObjects.GetComponent<DestroyedHuman>();
            if(destroyed != null )
            {
                destroyed.ExplodeBodies();
               
            }

            
   
        }
        Destroy(gameObject);
        Destroy(explosionEffectPreFab, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionSize);
    }
}
