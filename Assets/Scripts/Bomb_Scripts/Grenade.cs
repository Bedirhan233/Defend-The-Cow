

using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    float timer;
    bool hasExploded;

    public GameObject explosionEffect;

    public float force = 5;

    public float radius = 4;

    public float speed = 20;

    public float deacaleretion = 2;

    Vector3 velocity;

    float startSpeed = 20;
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
        speed -= Time.deltaTime;
        if(speed <= 0)
        {
            speed = 0;
        }
        velocity = transform.up * speed;
        Debug.Log("before " + velocity);

        velocity *= 1 - deacaleretion;

        Debug.Log("after " + velocity);

        transform.position += velocity;


        
        
    }

    void Explode()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);    
        GameObject explosionEffectPreFab = Instantiate(explosionEffect, transform.position, transform.rotation);
        foreach(Collider2D nearbyObjects in colliders)
        {
    
            Rigidbody2D rb = nearbyObjects.GetComponent<Rigidbody2D>();

            if(rb != null )
            {
                Vector2 direction = nearbyObjects.transform.position - transform.position;
                direction.Normalize();
                rb.AddForce(direction * force);
               Destroy(nearbyObjects.gameObject, 0.3f);
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
