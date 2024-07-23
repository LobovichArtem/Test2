using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName ="SimpleEnemyConfig", menuName = "Enemy/SimpleEnemyConfig") ]
public class SimpleEnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; } 

    [SerializeField] private Vector2 _speedRange;
    public float Speed => Random.Range(_speedRange.x, _speedRange.y);

    [SerializeField] private HpConfig _hpConfig;
    public int Hp => _hpConfig.Hp;
}
