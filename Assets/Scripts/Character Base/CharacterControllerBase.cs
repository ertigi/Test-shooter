using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterControllerBase : MonoBehaviour
{
    public event Action<float> OnTakeDamage;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    [Header("Skin Settings")]
    [SerializeField] private CharacterSkin _baseSkinPrefab;

    public WeaponMountPoint WeaponMount => _currentSkin?.WeaponMount;

    private NavMeshAgent _navMeshAgent;
    private CharacterSkin _currentSkin;
    private Vector2 _moveInput;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
        _navMeshAgent.angularSpeed = _rotationSpeed;
        _navMeshAgent.updateRotation = false;
    }

    private void Start()
    {
        if (_baseSkinPrefab != null)
            ApplySkin(_baseSkinPrefab);
        else
            Debug.LogWarning($"У {gameObject.name} отсуствует базовый скин");
    }

    private void Update()
    {
        HandleMovement();
        UpdateAnimator();
    }

    private void HandleMovement()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0f, _moveInput.y);

        if (direction.sqrMagnitude > 0.0001f)
        {
            _navMeshAgent.Move(direction.normalized * _moveSpeed * Time.deltaTime);
        }
    }

    private void UpdateAnimator()
    {
        if (_currentSkin?.Animator != null)
        {
            float speedPercent = _navMeshAgent.velocity.magnitude / _moveSpeed;
            _currentSkin.Animator.SetMoveSpeed(speedPercent);
        }
    }

    public void SetMoveInput(Vector2 input)
    {
        _moveInput = Vector2.ClampMagnitude(input, 1f);
    }

    public void EnableController(bool enable)
    {
        _navMeshAgent.enabled = enable;

        if (_currentSkin != null)
        {
            _currentSkin.Hitbox.Enable(enable);
            _currentSkin.Animator.Enable(enable);
        }
    }

    public void PlayShootAnimation()
    {
        _currentSkin?.Animator?.PlayShoot();
    }

    public void TakeDamage(float amount)
    {
        OnTakeDamage?.Invoke(amount);
    }

    public void ApplySkin(CharacterSkin skinPrefab)
    {
        if (skinPrefab == null)
        {
            Debug.LogWarning($"Попытка применить пустой скин к {gameObject.name}");
            return;
        }

        if (_currentSkin != null)
        {
            _currentSkin.Hitbox.OnTakeDamage -= TakeDamage;
            Destroy(_currentSkin.gameObject);
            _currentSkin = null;
        }

        var newSkin = Instantiate(skinPrefab, transform);
        _currentSkin = newSkin;

        _currentSkin.Hitbox.OnTakeDamage += TakeDamage;
    }
}
