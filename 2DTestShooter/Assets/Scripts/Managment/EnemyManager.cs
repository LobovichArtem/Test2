using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    [SerializeField] private Transform _finishPoint;

    private Player _player;

    [SerializeField] private EnemySpawner _enemySpawner;

    private List<Enemy> _activeEnemies;
    private Coroutine _checkEnemies;

    public UnityAction AllEnemiesDestroy;

    public void Initialize(Player player, EnemySpawner enemySpawner)
    {
        _player = player;
        _enemySpawner = enemySpawner;

        _enemySpawner.Initialize(_levelConfig);
        _enemySpawner.UnitSpawn += Add;

        _activeEnemies = new List<Enemy>();
    }

    [ContextMenu("StartSpawn")]
    public void StartSpawn()
    {
        if (_checkEnemies != null)
            throw new Exception("Spawn started");

        _enemySpawner.StartSpawn();
        _checkEnemies = StartCoroutine(CheckFinishLine());
        
    }

    public void StopSpawn()
    {
        StopCoroutine(_checkEnemies);
        _enemySpawner.StopSpawn();
    }

    private void OnDestroy()
    {
        _enemySpawner.UnitSpawn -= Add;
    }

    private void Add(Enemy enemy)
    {
        _activeEnemies.Add(enemy);
        enemy.Move(Vector2.down);
    }


    private void EnemyFinish(Enemy enemy)
    {
        _player.TakeDamage(1);
        EnemyRemove(enemy);
        
    }

    private void EnemyRemove(Enemy enemy)
    {
        _activeEnemies.Remove(enemy);
        enemy.Deactivate();
    }

    private IEnumerator CheckFinishLine()
    {
        while(true)
        {            
            if(_enemySpawner.AllUnitsSpawn && _activeEnemies.Count == 0)
            {
                AllEnemiesDestroy?.Invoke();
                StopSpawn();
                yield break;
            }

            Enemy[] enemies;
            if (_activeEnemies.Count > 0)
            {
                enemies = new Enemy[_activeEnemies.Count];
                _activeEnemies.CopyTo(enemies);

                foreach (Enemy enemy in enemies)
                {
                    if (enemy.IsAlive == false)
                    {
                        EnemyRemove(enemy);
                        continue;
                    }
                    if (enemy.transform.position.y < _finishPoint.position.y)
                        EnemyFinish(enemy);
                }
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
