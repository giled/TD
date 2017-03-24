using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform Spawnpoint;

    public float WavesLaikas = 5f;
    private float countdown = 2f;
    public Text waveCountdownText;



    private int WaveNumber = 0;
    private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = WavesLaikas;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
           


    }
    IEnumerator SpawnWave()
    {
        WaveNumber++;
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
      
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, Spawnpoint.position, Spawnpoint.rotation);
    }

}
