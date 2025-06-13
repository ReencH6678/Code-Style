using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] Transform _shootPosition;
    [SerializeField] float _shootingDeley;

    private bool _isOn = true;

    private ObjectPool<Bullet> _pool;

    private int _poolCpacity = 5;
    private int _poolMaxSize = 5;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_prefab, _shootPosition.position, Quaternion.identity),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCpacity,
            maxSize: _poolMaxSize
            );
    }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private void ActionOnGet(Bullet bullit)
    {
        transform.position = _shootPosition.position;
        bullit.gameObject.SetActive(true);
    }

    IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (_isOn)
        {
            _pool.Get();

            yield return new WaitForSeconds(_shootingDeley);
        }
    }
}