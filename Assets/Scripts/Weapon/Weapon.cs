using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 0.2f;
    [SerializeField] private Transform _firePoint;

    [Header("Aiming")]
    [SerializeField] private LayerMask _aimMask = ~0;
    [SerializeField] private float _aimMaxDistance = 1000f;

    private BulletService _bulletService;
    private bool _isShooting;
    private float _lastShootTime;

    public void Init(BulletService bulletService)
    {
        _bulletService = bulletService;
    }

    public void StartShooting() => _isShooting = true;
    public void StopShooting() => _isShooting = false;

    private void Update()
    {
        if (_isShooting && Time.time >= _lastShootTime + _fireRate)
        {
            Shoot();
            _lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (_bulletService == null || _firePoint == null) return;

        Camera cam = Camera.main;
        if (cam == null) return;

        Vector3 camPos = cam.transform.position;
        Vector3 camForward = cam.transform.forward;
        Vector3 targetPoint;

        if (Physics.Raycast(camPos, camForward, out var hit, _aimMaxDistance, _aimMask, QueryTriggerInteraction.Ignore))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = camPos + camForward * _aimMaxDistance;
        }

        Vector3 dir = (targetPoint - _firePoint.position).normalized;

        _bulletService.Shoot(_firePoint.position, dir, _damage);
    }
}