using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileStorage : MonoBehaviour
{
    [SerializeField] private Transform _reloadPosition;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Point _startPoint;
    [SerializeField] private Catapult _catapult;

    private ObjectPool<Projectile> _pool;
    private List<Projectile> _shells;

    private void Awake()
    {
        _pool = new(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: OnTakeFromPool,
            actionOnRelease: OnReturnedToPool,
            actionOnDestroy: (Projectile projectile) => Destroy(projectile)
            );

        _shells = new List<Projectile>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _shells.Count; i++)
        {
            Projectile currentProjectile = _shells[i];

            if (currentProjectile.transform.position.y < 0)
                _pool.Release(currentProjectile);
        }
    }

    public void Spawn()
    {
        _pool.Get();
    }

    private void OnReturnedToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _shells.Remove(projectile);
    }

    private void OnTakeFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.transform.position = _reloadPosition.position;
        _shells.Add(projectile);
    }
}
