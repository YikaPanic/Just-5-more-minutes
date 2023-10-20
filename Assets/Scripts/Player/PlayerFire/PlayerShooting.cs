using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject homingBulletPrefab;

    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    public float power = 10f;
    private float nextFireTime = 0f;

    [Header("Ability Enhancements")]
    public bool enableMultipleShots = true;

    public bool enableHomingShots = true;

    public int HomingShotsCount = 0;
    public int multipleShotsCount = 1;

    public bool enableSpreadShots = true;
    public int spreadShotCount = 1;
    public float spreadAngle = 45f;

    [Header("Coin Enhancements")]
    public int coinsCollected = 0;
    
    [Header("Ability Limits")]
    public int maxMultipleShotsCount = 5;
    public int maxSpreadShotCount = 5;

    [Header("Card Enhancement System")]
    public CardManager cardManager; // quote CardManager
    public int coinsForCardPanel = 2; // collect how many coins then display the card panel
    private int upgradesAcquired = 0; // track upgrade times
    public float coinIncreaseFactor = 1.0f; // coin requirement for next upgrade will be multiplied by IncreaseFactor

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            StartCoroutine(HomingShotCoroutine()); 

            if (enableMultipleShots)
            {
                StartCoroutine(MultipleShotCoroutine());
            }
            else
            {
                ShootBullet();
            }
            nextFireTime = Time.time + 1f/fireRate;
        }
    }
    
    public void CollectCoin()
    {
        coinsCollected++;
        FindObjectOfType<ScoreManager>().IncreaseScore(1);

        if (coinsCollected >= coinsForCardPanel)
        {
            cardManager.ShowCardPanel();
            coinsCollected = 0; 
            upgradesAcquired++; 

            // Dynamically adjust the required number of coins based on the player's upgrade frequency
            coinsForCardPanel = Mathf.CeilToInt(coinsForCardPanel + (coinIncreaseFactor + upgradesAcquired));
        }
    }

    IEnumerator MultipleShotCoroutine()
    {
        for (int i = 0; i < multipleShotsCount; i++)
        {
            ShootBullet(true);
            yield return new WaitForSeconds(0.1f);  
        }
    }

    IEnumerator HomingShotCoroutine()
    {
        if (enableHomingShots && HomingShotsCount > 0)
        {
            Vector2 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            for (int i = 0; i < HomingShotsCount; i++)
            {
                FireHomingBullet(shootingDirection);
                yield return new WaitForSeconds(0.1f);  // lag
            }
        }
    }
    
    void ShootBullet(bool fromCoroutine = false)
    {
        Vector2 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // spread bullets logic
        if (enableSpreadShots)
        {
            ShootSpreadBullets(spreadShotCount, spreadAngle);
        }
        // multiple bullets logic
        else if (enableMultipleShots)
        {
            for (int i = 0; i < multipleShotsCount; i++)
            {
                FireSingleBullet(shootingDirection);
            }
        }
        // defalut logic
        else
        {
            FireSingleBullet(shootingDirection);
        }
    }

    void FireSingleBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.up = direction;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bullet.GetComponent<Bullet>().damage = power;
    }

    public void ShootSpreadBullets(int count, float angleSpread)
    {
        Vector2 baseDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        if (count == 1)
        {
        // Directly shoot without angle adjustment
            FireBullet(baseDirection);
            return;
        }

        float startAngle = -angleSpread/2;
        float angleIncrement = angleSpread/(count-1);
        for (int i = 0; i < count; i++)
        {
            float angle = startAngle + angleIncrement * i;
            Vector2 shootingDirection = Quaternion.Euler(0, 0, angle) * baseDirection;
            FireBullet(shootingDirection);
        }
    }
    void FireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.up = direction;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bullet.GetComponent<Bullet>().damage = power;
    }

    void FireHomingBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.up = direction;
    }
}
