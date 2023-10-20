using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if bullet hits an enemy
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
