
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    float timer;
    bool hasExploded;

    public GameObject explosionEffect;

    public float force = 5;

    public float radius = 4;

    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        hasExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0 && !hasExploded)
        {
            Explode();
            hasExploded=true;
        }

        transform.position += transform.up * speed * Time.deltaTime;
    }

    void Explode()
    {
        // effect
        Debug.Log("BOM");
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);    
        GameObject explosionEffectPreFab = Instantiate(explosionEffect, transform.position, transform.rotation);
        foreach(Collider2D nearbyObjects in colliders)
        {
    
            Rigidbody2D rb = nearbyObjects.GetComponent<Rigidbody2D>();

            if(rb != null )
            {
                Vector2 direction = nearbyObjects.transform.position - transform.position;
                rb.AddForce(direction * force);
               Destroy(nearbyObjects.gameObject, 1);
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
