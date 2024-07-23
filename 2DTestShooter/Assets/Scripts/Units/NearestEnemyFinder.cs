using UnityEngine;

public class NearestEnemyFinder : IFinder
{
    private LayerMask _layerMask;
    private float _radius;
    private Transform _searchPoint;

    public NearestEnemyFinder(LayerMask layerMask, float radius, Transform searchPoint)
    {
        _layerMask = layerMask;
        _radius = radius;
        _searchPoint = searchPoint;
    }

    public GameObject Find()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_searchPoint.position, _radius, _layerMask);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector2.Distance(_searchPoint.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = collider.gameObject;
            }
        }

        return closestEnemy;
    }
}
