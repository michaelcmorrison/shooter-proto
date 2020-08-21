using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int _currentWave;
    [SerializeField] private int enemiesPerWave;

    private EnemySpawner _enemySpawner;
    private int _enemiesSpawned;

    [HideInInspector] public bool waveRunning;

    private void OnEnable()
    {
        EventManager.StartListening("EnemyDied", DecreaseSpawnedEnemies);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EnemyDied", DecreaseSpawnedEnemies);
    }

    private void DecreaseSpawnedEnemies()
    {
        _enemiesSpawned--;
    }

    private void Awake()
    {
        _enemySpawner = GetComponentInChildren<EnemySpawner>();
    }

    private void Update()
    {
        if (waveRunning)
        {
            if (CheckIfWaveDead())
            {
                waveRunning = false;
                EndWave();
            }
        }
    }

    private void EndWave()
    {
        _currentWave++;
        StartWave();
    }

    private bool CheckIfWaveDead()
    {
        return _enemiesSpawned == 0;
    }

    private void Start()
    {
        _currentWave = 1;
        StartWave();
    }

    private void StartWave()
    {
        EventManager.InvokeEvent("WaveStarted");
        var enemiesToSpawn = _currentWave * enemiesPerWave;
        _enemiesSpawned = enemiesToSpawn;
        StartCoroutine(_enemySpawner.SpawnEnemies(enemiesToSpawn));
        waveRunning = true;
    }

    public int GetCurrentWave()
    {
        return _currentWave;
    }
}
