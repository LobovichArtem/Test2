using UnityEngine;

[RequireComponent(typeof(Move))]
public class SimpleEnemy : Enemy
{
    protected override IDamagable Damagable { get; set; }
    private Move _move;

    public override bool IsAlive => Damagable.IsAlive;

    public override void Initialize(int hp, float speed)
    {
        Damagable = new SimpleDamage(hp);
        Damagable.OnDeath += Deactivate;

        _move = GetComponent<Move>();
        _move.Initialize(speed);
    }

    public override void Move(Vector2 direction) => _move.SetDirection(direction);

    public override void TakeDamage(int damage) => Damagable.TakeDamage(damage);
    

    public override void Deactivate()
    {
        Damagable.OnDeath -= Deactivate;
        gameObject.SetActive(false);
    }
    
}
