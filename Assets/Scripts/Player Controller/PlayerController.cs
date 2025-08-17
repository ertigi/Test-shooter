using System;
using UnityEngine;

public class PlayerController
{
    public event Action<float> OnHealthChanged;
    public event Action OnDied;

    private readonly CharacterControllerBase _characterController;
    private readonly InputService _inputService;
    private readonly CameraObject _cameraObject;
    private float _health;

    public float Health => _health;

    public PlayerController(CharacterSkinsContainer skinsContainer, InputService inputService, CameraObject cameraObject)
    {
        _characterController = UnityEngine.Object.Instantiate(skinsContainer.Player);

        _inputService = inputService;
        _cameraObject = cameraObject;
        _health = 100f;

        _cameraObject.SetTraget(_characterController.CameraTarget);

        _inputService.OnMove += OnMoveInput;
        _inputService.OnShoot += OnShoot;

        _characterController.OnTakeDamage += TakeDamage;
    }

    private void OnMoveInput(Vector2 input)
    {
        Vector3 cameraForward = _cameraObject.CameraTransform.forward;
        Vector3 cameraRight = _cameraObject.CameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * input.y + cameraRight * input.x;

        _characterController.SetMoveInput(new Vector2(moveDirection.x, moveDirection.z));
        _characterController.RotateSkin(cameraForward);
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