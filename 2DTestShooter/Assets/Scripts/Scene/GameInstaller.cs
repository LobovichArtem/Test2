using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private LevelConfig _levelConfig;

    void Awake()
    {
        Player player = Instantiate(_playerPrefab).GetComponent<Player>();

        player.Initialize();
        _enemySpawner.Initialize(_levelConfig);
        _enemyManager.Initialize(player, _enemySpawner);
        _levelManager.Initialize(player, _enemyManager);

    }
}