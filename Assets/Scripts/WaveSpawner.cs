using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Enemy enemy;
        public int amount;
        public float rate;
    }

    [SerializeField]
    private WaveProperties[] waves = null;
    private int nextWave = 0;

    [SerializeField]
    private EnemySpawnPoint[] spawnPoints;

    [SerializeField]
    private float timeStartNextWave = 5f;
    private float waveCountdown;

    private float checkEnemyCountdown = 1.0f;

    private SpawnState state = SpawnState.COUNTING;

    public event Action<int> OnWaveDefined = delegate { };
    public event Action<int> OnWaveChanged = delegate { };

    private void Start()
    {
        spawnPoints = GameObject.FindObjectsOfType<EnemySpawnPoint>();
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn point is referenced.");
        }

        if(waves == null)
        {
            Debug.LogError("No Wave is referenced");
        }

        waveCountdown = timeStartNextWave;
        Debug.Log(waves.Length);
        Debug.Log(nextWave + 1);
        OnWaveDefined(waves.Length);
        OnWaveChanged(nextWave + 1);
    }

    private void Update()
    {
        if (state == SpawnState.FINISHED)
        {
            return;
        }

        if(state == SpawnState.WAITING)
        {
            if (!isEnemyAlive())
            {
                //Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0.0f)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private bool isEnemyAlive()
    {
        checkEnemyCountdown -= Time.deltaTime;
        if (checkEnemyCountdown <= 0.0f)
        {
            checkEnemyCountdown = 1.0f;
            if (GameObject.FindObjectOfType<Enemy>() == null)
            {
                return false;
            }
        }
        return true;
    }

    private void WaveCompleted()
    {
            
        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("All Waves completed");
            state = SpawnState.FINISHED;
        }
        else
        {
            Debug.Log("Wave Completed");

            state = SpawnState.COUNTING;
            waveCountdown = timeStartNextWave;

            nextWave++;
        }
        Debug.Log(nextWave + 1);
        OnWaveChanged(nextWave + 1);
    }

    IEnumerator SpawnWave(WaveProperties wave)
    {
        Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.Amount; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1.0f / wave.Rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnEnemy(Enemy enemy)
    {
        Debug.Log("Spawning Enemy");
        EnemySpawnPoint spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
    }
}
