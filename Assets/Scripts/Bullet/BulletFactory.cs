using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    private readonly Bullet _bulletPrefab;
    private readonly Transform _parent;
    private readonly Queue<Bullet> _pool = new Queue<Bullet>();

    public BulletFactory(Bullet bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
        _parent = new GameObject("Bullets").transform;
    }

    public Bullet GetBullet(Vector3 position, Vector3 forward, float damage)
    {
        Bullet bullet;
        if (_pool.Count > 0)
        {
            bullet = _pool.Dequeue();
            bullet.transform.SetParent(_parent);
            bullet.transform.position = position;
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Object.Instantiate(_bulletPrefab, position, Quaternion.identity, _parent);
        }

        bullet.transform.forward = forward;
        bullet.Init(damage);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}
