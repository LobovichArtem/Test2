using UnityEngine;
using Zenject;

[RequireComponent(typeof(Move), typeof(PlayerUIHp))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerConfig _playerConfig;

    private PlayerController _playerController;
    private Move _move;
    public IDamagable Damagable { get; private set; }
    private Attack _attack;
    private IHpUI _hpUi;

    public void TakeDamage(int damage) => Damagable.TakeDamage(damage);

    [Inject]
    public void Initialize()
    {
        Debug.Log("Plauer Initialize");
        _playerController = new PlayerController();
        _playerController.OnEnable();

        _move = GetComponent<Move>();
        _move.Initialize(_playerConfig.Speed);

        _hpUi = GetComponent<IHpUI>();

        Damagable = new SimpleDamage(_playerConfig.Hp);

        RendererHp(Damagable.Hp);
        Damagable.OnTakeDamage += RendererHp;

        _attack = new Attack(new NearestEnemyFinder(_playerConfig.EnemyLayer, _playerConfig.Radius, transform), new ObjectPool(_playerConfig.BulletPrefab), _playerConfig.GunConfig, transform);
    }

    private void OnDisable()
    {
        _playerController.OnDisable();

        Damagable.OnTakeDamage -= RendererHp;
    }

    private void Update()
    {
        _move.SetDirection(_playerController.MoveDirection);

        _attack.Update();
    }

    private void RendererHp(int damage) => _hpUi.RendererHp(Damagable.Hp);

}

