using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int MoveParam = Animator.StringToHash("MoveSpeed");
    private static readonly int ShootParam = Animator.StringToHash("Shoot");
    private static readonly int SpawnParam = Animator.StringToHash("Spawn");
    private static readonly int DieParam = Animator.StringToHash("Die");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public bool IsAnimationDieFinished() => IsAnimationFinished(DieParam);
    public bool IsAnimationSpawnFinished() => IsAnimationFinished(SpawnParam);

    public void SetMoveSpeed(float speedPercent) => _animator.SetFloat(MoveParam, speedPercent);
    public void PlayShoot() => _animator.SetTrigger(ShootParam);

    public void Spawn() => _animator.SetTrigger(SpawnParam);
    public void Die() => _animator.SetTrigger(DieParam);

    public void Enable(bool enable) => _animator.enabled = enable;

    private bool IsAnimationFinished(int animationHash)
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == animationHash)
        {
            if (!stateInfo.loop)
                return stateInfo.normalizedTime >= 1f;
        }

        return false;
    }
}
