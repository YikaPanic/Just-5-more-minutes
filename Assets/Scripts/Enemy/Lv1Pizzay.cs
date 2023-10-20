using UnityEngine;

public class BasicPizzaMonster : Enemy
{
    public float socre = 1f;
    public GameObject deathEffectPrefab;
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Spawn coin at enemy's position
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            SpawnCoin(gameObject.transform.position);
            FindObjectOfType<ScoreManager>().IncreaseScore(socre);
            Destroy(gameObject);
        }
    }
}
