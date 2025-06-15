using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _shootingDeley;

    private bool _isOn = true;

    private ObjectPool<Bullet> _pool;

    private int _poolCpacity = 5;
    private int _poolMaxSize = 5;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_prefab, _shootPosition.position, Quaternion.identity),
            actionOnGet: (obj) => GetBullet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCpacity,
            maxSize: _poolMaxSize
            );
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void GetBullet(Bullet bullet)
    {
        bullet.transform.position = _shootPosition.position;
        bullet.gameObject.SetActive(true);
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_shootingDeley);
        bool isWork = enabled;

        while (_isOn)
        {
            _pool.Get();

            yield return waitForSeconds;
        }
    }
}