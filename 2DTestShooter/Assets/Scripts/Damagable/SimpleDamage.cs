using System;

public class SimpleDamage : IDamagable
{
    
    public event Action OnDeath;
    public event Action<int> OnTakeDamage;

    public int Hp { get; private set; }
    public bool IsAlive => Hp > 0;

    public SimpleDamage(int currentHp)
    {
        Hp = currentHp;
    }


    public void SetCurrentHealth(int health)
    {
        if (health <= 0)
        {
            throw new ArgumentException("Health cannot be less than or equal to zero.");
        }

        Hp = health;
    }

    public void TakeDamage(int damage)
    {
        if (!IsAlive)
        {
            return;
        }

        if (damage <= 0)
        {
            throw new ArgumentException("Damage cannot be less than or equal to zero.");
        }

        Hp -= damage;
        OnTakeDamage?.Invoke(damage);

        if (Hp <= 0)
        {
            Die();
        }        
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }

}
