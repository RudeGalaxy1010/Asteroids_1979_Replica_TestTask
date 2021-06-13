using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _cooldownTime;
    private bool _isCoolDown;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _isCoolDown = false;
    }

    void Update()
    {
        if (!_isCoolDown && Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _isCoolDown = true;
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(_cooldownTime);
        _isCoolDown = false;
    }
}
