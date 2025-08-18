using System.Collections.Generic;
using UnityEngine;

public class BulletService : IUpdateService
{
    private readonly BulletFactory _factory;
    private readonly List<Bullet> _activeBullets = new List<Bullet>();

    public BulletService(Bullet bulletPrefab)
    {
        _factory = new BulletFactory(bulletPrefab);
    }

    public void Shoot(Vector3 position, Vector3 forward, float damage)
    {
        Bullet bullet = _factory.GetBullet(position, forward, damage);
        _activeBullets.Add(bullet);
    }

    public void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        for (int i = _activeBullets.Count - 1; i >= 0; i--)
        {
            Bullet bullet = _activeBullets[i];
            if (bullet.IsActive)
            {
                bullet.UpdateBullet(deltaTime);
            }
            else
            {
                _factory.ReturnBullet(bullet);
                _activeBullets.RemoveAt(i);
            }
        }
    }
}
