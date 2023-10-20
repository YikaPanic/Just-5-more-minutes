using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingBullet : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 200f;
    public float damage = 10f; 
    public float lifeTime = 2f; 

    private GameObject target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindClosestEnemy();
        Destroy(gameObject, lifeTime); // set lifetime
    }

    void Update()
    {
        if (target == null)
        {
            FindClosestEnemy();
            if (target == null)
                return;
        }

        Vector2 direction = (Vector2)target.transform.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy;
        }
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

