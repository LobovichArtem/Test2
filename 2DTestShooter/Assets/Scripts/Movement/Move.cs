using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rigidbody;

    private Vector2 _direction;

    public void Initialize(float newSpeed)
    {
        if (newSpeed <= 0)
        {
            throw new ArgumentException("Speed must be greater than zero.");
        }

        _speed = newSpeed;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}