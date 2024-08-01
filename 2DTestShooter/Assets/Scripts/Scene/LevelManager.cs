using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPopap;
    [SerializeField] private GameObject _losePopap;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;

    private EnemyManager _enemyManager;

    private Player _player;

    public void Initialize(Player player, EnemyManager enemyManager)
    {
        _player = player;
        _enemyManager = enemyManager;

        _enemyManager.AllEnemiesDestroy += Winner;
        _player.Damagable.OnDeath += Lose;

        _startButton.onClick.AddListener(_enemyManager.StartSpawn);
        _restartButton.onClick.AddListener(RestartScene);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(_enemyManager.StartSpawn);
        _restartButton.onClick.RemoveListener(RestartScene);
    }

    private void RestartScene()
    {
        //here all resources are cleared and a new level starts, or now the scene is simply reloaded
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void Lose()
    {
        _losePopap.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }

    private void Winner()
    {
        _winPopap.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }
}
