using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private TrailRenderer _trailRenderer;
    private Vector3 _prevPos;
    private float _damage;
    private float _timer;
    private bool _active;

    public bool IsActive => _active;

    public void Init(float damage)
    {
        _damage = damage;
        _prevPos = transform.position;
        _active = true;
        _trailRenderer.Clear();
        _timer = _lifeTime;
    }

    public void Deactivate()
    {
        _active = false;
        gameObject.SetActive(false);
    }

    public void UpdateBullet(float dt)
    {
        if (!_active) return;

        Vector3 nextPos = transform.position + transform.forward * _speed * dt;
        transform.position = nextPos;

        Vector3 dir = nextPos - _prevPos;
        float dist = dir.magnitude;

        if (dist > 0f && Physics.Raycast(_prevPos, dir.normalized, out var hit, dist, ~0, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.TryGetComponent(out IDamageable dmg))
                dmg.TakeDamage(_damage);

            Deactivate();
            return;
        }

        _timer -= dt;

        if(_timer < 0)
        {
            Deactivate();
            return;
        }

        _prevPos = nextPos;
    }
}