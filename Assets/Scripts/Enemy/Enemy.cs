using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float health = 100f;
    public float speed = 5f;
    public float attackDamage = 10f;
    public float attackRange = 1f;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected Transform player;
    protected bool isBiting = false;

    public GameObject coinPrefab;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isBiting)
        {
            MoveTowardsPlayer();
            // Check if player is within attack range
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
        }
        else
        {
            // End attack if player moves out of attack range
            if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                StopBiting();
            }
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = moveDirection * speed;

        Flip(moveDirection.x);
    }

    protected virtual void AttackPlayer()
    {
        isBiting = true;
        animator.SetBool("IsBiting", true);
        rb.velocity = Vector2.zero;  // Stop the enemy's movement
    }

    public abstract void TakeDamage(float damage);

    protected void SpawnCoin(Vector3 position)
    {
        Instantiate(coinPrefab, position, Quaternion.identity);
    }

    public void StopBiting()
    {
        isBiting = false;
        animator.SetBool("IsBiting", false);
    }

    protected void Flip(float horizontalInput)
    {
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
