using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
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
        while (waveNumber < 20)
        {
            waveNumber++;
            waveCounterText.text = "Wave: " + waveNumber;

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }

            enemiesPerWave += 1;
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        // When wave 20 ends, load Win Scene
        SceneManager.LoadScene("Youwinmenu"); 
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
