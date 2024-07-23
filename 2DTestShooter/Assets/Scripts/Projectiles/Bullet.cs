using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;
    private float _speed;
    private Transform _target;
    private event Action<Bullet> _reachedTarget; 

    public void Initialize(float speed, int damage, Vector2 startPos, Transform target, Action<Bullet> reachedTarget)
    {
        _speed = speed;
        _damage = damage;
        _target = target;
        _reachedTarget += reachedTarget;
        transform.position = startPos;
    }

    public void Move()
    {        
        var dir = _target.position - transform.position;
        if (dir.magnitude > .1f)
            transform.Translate(dir.normalized * _speed * Time.deltaTime);
        else
            TakeDamage();
    }

    private void TakeDamage()
    {
        if (_target.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
        _reachedTarget?.Invoke(this);
        gameObject.SetActive(false);
    }
}
