using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform Spawnpoint;

    public float WavesLaikas = 5f;
    private float countdown = 2f;


    public Text waveCountdownText;



    private int WaveNumber = 0;
    private void Update()
    {
        if (EnemiesAlive>0)
        {
            return;
        }

        if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = WavesLaikas;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
           


    }
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;
        Wave wave = waves [WaveNumber];


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        WaveNumber++;
        if (WaveNumber==waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, Spawnpoint.position, Spawnpoint.rotation);
        EnemiesAlive++;
    }

}
