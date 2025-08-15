using UnityEngine;
using System;

[RequireComponent(typeof(CapsuleCollider))]
public class CharacterHitbox : MonoBehaviour
{
    public event Action<float> OnTakeDamage;

    private CapsuleCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(float amount)
    {
        OnTakeDamage?.Invoke(amount);
    }

    public void Enable(bool enable)
    {
        _collider.enabled = enable;
    }
}
