
public class SimpleEnemyFactory : IUnitsFactory
{
    private ObjectPool _unitsPool;
    private Enemy _prefab;

    public SimpleEnemyFactory(Enemy prefab)
    {
        _prefab = prefab;
        _unitsPool = new ObjectPool(prefab.gameObject);
    }

    public SimpleEnemyFactory(Enemy prefab, int startCount)
    {
        _prefab = prefab;
        _unitsPool = new ObjectPool(prefab.gameObject, startCount);
    }

    public Enemy Get() => _unitsPool.Get().GetComponent<Enemy>();

   
}
