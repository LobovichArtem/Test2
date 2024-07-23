using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints = new Transform[1];
    private Vector2 GetRandomPosition => _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

    private LevelConfig _levelConfig;
    private float Timeout => _levelConfig.TimeoutSpawn;
    private SimpleEnemyConfig EnemyConfig => _levelConfig.SimpleEnemyConfig;
    private Enemy Prefab => EnemyConfig.Prefab;

    private IUnitsFactory enemyFactory;    

    private Coroutine _spawnCoroutine;
    public event Action<Enemy> UnitSpawn;

    public bool AllUnitsSpawn { get; private set; }


    public void Initialize(LevelConfig levelConfig)
        => _levelConfig = levelConfig;

    [ContextMenu("StartSpawn")]
    public void StartSpawn()
    {
        if (_levelConfig == null)
            throw new ArgumentNullException("Not Initialize LevelConfig");
        enemyFactory = new SimpleEnemyFactory(Prefab, 5);
        var count = _levelConfig.EnemyCount;
        if (_spawnCoroutine == null)
            _spawnCoroutine = StartCoroutine(Spawn(count));
    }

    public void StopSpawn()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator Spawn(int count)
    {
        AllUnitsSpawn = false;
        while (count > 0)
        {
            yield return new WaitForSeconds(Timeout);

            Enemy unit = enemyFactory.Get();
            unit.transform.position = GetRandomPosition;
            unit.Initialize(EnemyConfig.Hp, EnemyConfig.Speed);

            UnitSpawn?.Invoke(unit);

            count--;
        }

        AllUnitsSpawn = true;
    }

    
}
