using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5; // player's life point
    private int maxHealth = 5;
    private bool isInvincible = false;
    public Sprite[] healthSprites; 
    public SpriteRenderer healthUI; // UI's 'SpriteRenderer
    private bool isCardInvincibilityActive = false;
    public SpriteRenderer shieldSpriteRenderer; // Invincible shield Renderer
 
    private void Start()
    {
        maxHealth = health;
        shieldSpriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is hit by an enemy attack
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            TakeDamage(1); // Assumes each enemy attack deals 1 damage
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isInvincible)
        {
            health -= damageAmount;
            UpdateHealthUI();
            StartCoroutine(InvincibilityCoroutine());
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();
    }
    
    private IEnumerator InvincibilityCoroutine()
    {
        if(!isCardInvincibilityActive) 
        {
            isInvincible = true;
            yield return new WaitForSeconds(1f);
            isInvincible = false;
        }
    }

    private void Die()
    {
        // Restart the game by reloading the StartScene
        SceneManager.LoadScene("LoseScene");
    }

    void UpdateHealthUI()
    {
        if (health >= 0 && health < healthSprites.Length)
        {
            healthUI.sprite = healthSprites[health];
        }
    }

    public void StartInvincibility(float duration)
    {
        isCardInvincibilityActive = true;
        shieldSpriteRenderer.enabled = true;
        StartCoroutine(InvincibilityDurationCoroutine(duration));
    }

    private IEnumerator InvincibilityDurationCoroutine(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isCardInvincibilityActive = false;
        isInvincible = false;
        shieldSpriteRenderer.enabled = false;
    }
}
