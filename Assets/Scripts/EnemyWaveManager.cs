using UnityEngine;
using TMPro;

public class EnemyWaveManager : MonoBehaviour
{
    [Header("Wave Settings")]
    public WaveData[] waves;
    public Transform[] spawnPoints;

    private int currentWaveIndex = 0;
    private int enemiesAlive = 0;

    [Header("UI")]
    public TMP_Text waveText;
    public TMP_Text enemyCounterText;
    public TMP_Text winText;

    void Start()
    {
        winText.text = "";
        StartWave();
    }

    void StartWave()
    {
        // Voitto
        if (currentWaveIndex >= waves.Length)
        {
            waveText.text = "Wave: COMPLETE";
            enemyCounterText.text = "";
            winText.text = "YOU WIN!";
            return;
        }

        WaveData wave = waves[currentWaveIndex];

        waveText.text = $"Wave: {currentWaveIndex + 1}";

        enemiesAlive = wave.enemyCount;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(wave.enemyPrefab, spawn.position, Quaternion.identity);

            Enemy enemyScript = enemy.AddComponent<Enemy>();
            enemyScript.manager = this;
        }

        UpdateUI();
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        UpdateUI();

        if (enemiesAlive <= 0)
        {
            currentWaveIndex++;
            Invoke(nameof(StartWave), 1.5f);
        }
    }

    void UpdateUI()
    {
        enemyCounterText.text = $"Enemies Left: {enemiesAlive}";
    }
}
