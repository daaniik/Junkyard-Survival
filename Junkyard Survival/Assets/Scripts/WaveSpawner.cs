using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this at the top


public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // 4 enemy prefabs in Inspector
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 5;
    public TMP_Text waveCounterText;

    private int waveNumber = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    System.Collections.IEnumerator SpawnWaves()
    {
        while (true)
        {
            waveNumber++;
            waveCounterText.text = "Wave: " + waveNumber;

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f); // time between spawns
            }

            enemiesPerWave += 1; // optional: scale difficulty
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
