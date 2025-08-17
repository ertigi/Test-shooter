using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int MoveParam = Animator.StringToHash("MoveSpeed");
    private static readonly int ShootParam = Animator.StringToHash("Shoot");
    private static readonly int SpawnParam = Animator.StringToHash("IsSpawn");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveSpeed(float speedPercent)
    {
        _animator.SetFloat(MoveParam, speedPercent);
    }

    public void PlayShoot()
    {
        _animator.SetTrigger(ShootParam);
    }

    public void Spawn()
    {
        _animator.SetTrigger(SpawnParam);
    }

    public void Enable(bool enable)
    {
        _animator.enabled = enable;
    }
}
