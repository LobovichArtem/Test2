using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    private IFinder _enemyFinder;
    private float _lastShotTime;

    private GunConfig _gunConfig;
    private float FireRate => _gunConfig.FireRate;

    private ObjectPool _objectPool;

    private List<Bullet> _currentBullets;

    private Transform _shotPoint;

    public Attack(IFinder iFinder, ObjectPool objectPool, GunConfig gunConfig, Transform shotPoint)
    {
        _enemyFinder = iFinder;
        _objectPool = objectPool;
        _gunConfig = gunConfig;
        _shotPoint = shotPoint;

        _lastShotTime = 0f;
        _currentBullets = new List<Bullet>();
    }

    public void Update()
    {
        Bullet[] bullets = new Bullet[_currentBullets.Count];
        _currentBullets.CopyTo(bullets);

        foreach (Bullet bullet in bullets)
            bullet.Move();

        if (Time.time < _lastShotTime + FireRate)
            return;

        var enemy = _enemyFinder.Find();
        if (enemy != null)
        {
            Shoot(enemy);
            _lastShotTime = Time.time;
        }

    }

    private void Shoot(GameObject enemy)
    {
        Bullet projectile = _objectPool.Get().GetComponent<Bullet>();
        projectile.Initialize(_gunConfig.BulletSpeed, _gunConfig.Damage, _shotPoint.position, enemy.transform, Remove);

        if(_currentBullets.Contains(projectile) == false)
            _currentBullets.Add(projectile);
    }

    private void Remove(Bullet bullet) => _currentBullets.Remove(bullet);
}
