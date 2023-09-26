

using Unity.Burst.Intrinsics;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public float force = 5;
    public float radius = 4;
    public float speed = 20;
    public float deacaleretion;

    

    

    public GameObject explosionEffect;

    bool hasExploded;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        hasExploded = false;


       
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


        deacaleretion = deacaleretion - 0.01f;

        if(deacaleretion < 0)
        {
            deacaleretion = 0;
        }

        // throw it to the mouse position



        transform.position += transform.up * speed * deacaleretion * Time.deltaTime;

    }

    void Explode()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);    
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
                rb.AddForce(direction * force);
                
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
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}