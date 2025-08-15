using UnityEngine;
using System;

public class PlayerController
{
    private readonly CharacterControllerBase _characterController;
    private readonly InputService _inputService;

    private float _health;
    public float Health => _health;

    public event Action<float> OnHealthChanged;
    public event Action OnDied;

    public PlayerController(CharacterControllerBase characterController, InputService inputService)
    {
        _characterController = characterController;
        _inputService = inputService;
        _health = 100f;

        _inputService.OnMove += OnMoveInput;
        _inputService.OnShoot += OnShoot;

        _characterController.OnTakeDamage += TakeDamage;
    }

    private void OnMoveInput(Vector2 move)
    {
        _characterController.SetMoveInput(move);
    }

    private void OnShoot(bool isShooting)
    {
        // _weapon.SetShooting(isShooting);

        if (isShooting)
            _characterController.PlayShootAnimation();
    }

    private void TakeDamage(float damage)
    {
        _health = Mathf.Max(_health - damage, 0f);
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0f)
            Die();
    }

    private void Die()
    {
        OnDied?.Invoke();
        _characterController.EnableController(false);
    }

    public void Dispose()
    {
        _inputService.OnMove -= OnMoveInput;
        _inputService.OnShoot -= OnShoot;
        _characterController.OnTakeDamage -= TakeDamage;
    }
}
