using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;        // Enemy to spawn
    public int enemiesPerWave = 3;        // Starting enemies per wave
    public float difficultyMultiplier = 1.2f; // How much the wave grows each round

    private int currentWave = 1;        // How many enemies spawn each wave
    public float spawnRadius = 3f;        // Radius around the spawner to spawn enemies

    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool waveActive = false;

    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        // Remove null entries
        activeEnemies.RemoveAll(e => e == null);

        if (waveActive && activeEnemies.Count == 0)
        {
            waveActive = false;
            Invoke(nameof(SpawnWave), 1f); // Delay before next wave
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < Mathf.RoundToInt(enemiesPerWave); i++)
        {
            Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            activeEnemies.Add(enemy);
        }

        waveActive = true;

        // Increase difficulty for next wave
        currentWave++;
        enemiesPerWave = Mathf.RoundToInt(enemiesPerWave * difficultyMultiplier);
    }
}
