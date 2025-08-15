using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
    [field: SerializeField] public CharacterAnimator Animator { get; private set; }
    [field: SerializeField] public CharacterHitbox Hitbox { get; private set; }
    [field: SerializeField] public WeaponMountPoint WeaponMount { get; private set; }

    private void Awake()
    {
        if (!Animator)
            Debug.LogWarning($"В скине - {gameObject.name} не указан Animator");

        if (!Hitbox)
            Debug.LogWarning($"В скине - {gameObject.name} не указан Hitbox");

        if (!WeaponMount)
            Debug.LogWarning($"В скине - {gameObject.name} не указан WeaponMount");
    }
}
