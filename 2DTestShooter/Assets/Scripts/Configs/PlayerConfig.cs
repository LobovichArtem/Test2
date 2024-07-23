using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private HpConfig _hpConfig;
    public int Hp => _hpConfig.Hp;

    [field: SerializeField, Range(.1f, 10f)] public float Speed { get; set; }

    [field: SerializeField] public GunConfig GunConfig { get; private set; }
    public float FireRate => GunConfig.FireRate;
    public int Damage => GunConfig.Damage;
    public float BulletSpeed => GunConfig.BulletSpeed;
    public float Radius => GunConfig.Radius;

    [field: SerializeField] public LayerMask EnemyLayer { get; private set; }

    [field: SerializeField] public GameObject BulletPrefab { get; set; }

}
