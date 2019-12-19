using UnityEngine;
using UnityEngine.UI;

public class UIUpdateWave : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private WaveSpawner spawner;

    private int currentWave = 0;
    private int maxWaves = 0;

    private void Awake()
    {
        spawner = FindObjectOfType<WaveSpawner>();
        spawner.OnWaveChanged += HandleWaveChanged;
        spawner.OnWaveDefined += HandleWaveDefined;
    }

    private void HandleWaveChanged(int wave)
    {
        currentWave = wave;
    }

    private void HandleWaveDefined(int wave)
    {
        currentWave = wave;
        maxWaves = wave;
    }

    private void Update()
    {
        text.text = $"Wave: {currentWave}/{maxWaves}";
    }

    private void OnDestroy()
    {
        spawner.OnWaveChanged -= HandleWaveChanged;
        spawner.OnWaveDefined -= HandleWaveDefined;
    }
}
