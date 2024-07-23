
using System;

public interface IDamagable
{
    event Action OnDeath;
    event Action<int> OnTakeDamage;

    bool IsAlive { get; }

    int Hp { get; }

    void SetCurrentHealth(int health);

    void TakeDamage(int damage);

    void Die();
}
