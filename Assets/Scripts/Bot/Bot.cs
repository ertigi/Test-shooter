using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private CharacterControllerBase _characterController;
    [SerializeField] private BotSettings _settings;
    private BotFSM _fsm;
    private Weapon _weapon;
    private float _currentMaxHealth;
    private float _health;

    public BotFSM FSM => _fsm;
    public BotSettings BotSettings => _settings;
    public CharacterControllerBase CharacterController => _characterController;
    public Weapon Weapon => _weapon;

    public float MaxHealth => _currentMaxHealth;
    public float Health => _health;


    public void Init(CharacterSkin skin, WeaponFactory weaponFactory, Transform player)
    {
        _characterController.ApplySkin(skin);
        _weapon = weaponFactory.CreateWeapon(WeaponType.Rifle, _characterController.WeaponMount.Mount);
        _fsm = new BotFSM(this, player);
    }

    public void Respawn()
    {
        _currentMaxHealth = Random.Range(_settings.MinMaxHealth.x, _settings.MinMaxHealth.y);
        _health = _currentMaxHealth;

        _characterController.Skin.Animator.Spawn();
    }

    public bool CanSeePlayer(Transform player)
    {
        Vector3 dir = player.position - transform.position;
        if (Physics.Raycast(transform.position + Vector3.up, dir.normalized, out var hit, _settings.AttackDistance))
            return hit.collider.CompareTag("Player");
        return false;
    }

    public void SetDestination(Vector3 position)
    {
        _characterController.SetDestination(position);
    }
}
