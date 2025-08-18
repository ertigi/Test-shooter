using System;
using UnityEngine;

public class PlayerController
{
    public event Action<float> OnHealthChanged;
    public event Action OnDied;

    private readonly CharacterControllerBase _characterController;
    private readonly InputService _inputService;
    private readonly CameraObject _cameraObject;
    private readonly WeaponFactory _weaponFactory;
    private Weapon _weapon;
    private float _health;

    public Transform Transform => _characterController.transform;
    public float Health => _health;

    public PlayerController(CharacterSkinsContainer skinsContainer, InputService inputService, CameraObject cameraObject, WeaponFactory weaponFactory)
    {
        _characterController = UnityEngine.Object.Instantiate(skinsContainer.Player);

        _inputService = inputService;
        _cameraObject = cameraObject;
        _weaponFactory = weaponFactory;
        _health = 100f;

        _cameraObject.SetTraget(_characterController.CameraTarget);

        _weapon = _weaponFactory.CreateWeapon(WeaponType.Rifle, _characterController.WeaponMount.Mount);

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
        if(isShooting)
            _weapon.StartShooting();
        else
            _weapon.StopShooting();

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

public class Player : MonoBehaviour
{

}