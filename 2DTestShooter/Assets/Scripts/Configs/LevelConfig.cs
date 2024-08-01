using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Level/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private Vector2Int _enemyCountRange;
    [SerializeField] private Vector2 _timeoutSpawnRange;

    public int EnemyCount => Random.Range(_enemyCountRange.x, _enemyCountRange.y);
    public float TimeoutSpawn => Random.Range(_timeoutSpawnRange.x, _timeoutSpawnRange.y);

    [SerializeField] private SimpleEnemyConfig _enemyConfig;
    public SimpleEnemyConfig SimpleEnemyConfig => _enemyConfig;

}
