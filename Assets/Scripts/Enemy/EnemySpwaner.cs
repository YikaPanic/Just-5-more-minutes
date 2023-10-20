using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float startTime;

    [System.Serializable]
    public class SpawnData
    {
        
        public float spawnStartTime;  // Time to start generating monsters
        public float spawnEndTime;    // Time to stop generating monsters
        public GameObject[] enemiesToSpawn; // types of monsters generating in this period
        public float spawnRate; // rate of generating in this period
    }

    public SpawnData[] spawnDataArray;

    [Header("Spawn Settings")]
    public Vector2 spawnCenter;  // centre of spawn area
    public Vector2 spawnRange = new Vector2(5f, 5f); // control size of spawn area

    private bool isSpawning = false;
    private float nextSpawnTime = 0f;
    private SpawnData currentSpawnData;

    private void Start()
    {
        startTime = Time.time;
        nextSpawnTime = 0f;
        isSpawning = true;
        currentSpawnData = null;
        StartSpawning();
    }

    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (isSpawning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateCurrentSpawnData(elapsedTime);

            if (elapsedTime >= nextSpawnTime && currentSpawnData != null)
            {
                SpawnEnemy();
                nextSpawnTime = elapsedTime + 1f / currentSpawnData.spawnRate;
            }
            yield return null;
        }
    }

    private void UpdateCurrentSpawnData(float elapsedTime)
    {
        foreach (var spawnData in spawnDataArray)
        {
            if (elapsedTime >= spawnData.spawnStartTime && elapsedTime <= spawnData.spawnEndTime)
            {
                currentSpawnData = spawnData;
                return;
            }
        }
        currentSpawnData = null;
    }

    private void SpawnEnemy()
    {
        if (currentSpawnData == null || currentSpawnData.enemiesToSpawn.Length == 0) return;

        int randomIndex = Random.Range(0, currentSpawnData.enemiesToSpawn.Length);
        GameObject enemyToSpawn = currentSpawnData.enemiesToSpawn[randomIndex];
        Vector2 spawnPosition = new Vector2(
            spawnCenter.x + Random.Range(-spawnRange.x, spawnRange.x),
            spawnCenter.y + Random.Range(-spawnRange.y, spawnRange.y)
        );

        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnCenter, new Vector3(spawnRange.x * 2, spawnRange.y * 2, 0));
    }
}
