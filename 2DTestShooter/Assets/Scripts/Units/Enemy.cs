using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected abstract IDamagable Damagable { get; set; }

    public abstract bool IsAlive { get; }

    public abstract void Initialize(int hp, float speed);

    public abstract void Move(Vector2 direction);

    public abstract void TakeDamage(int damage);

    public abstract void Deactivate();
}
