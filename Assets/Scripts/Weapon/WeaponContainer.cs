using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Container", menuName = "Game/Weapon Container")]
public class WeaponContainer : ScriptableObject
{
    [System.Serializable]
    public class WeaponEntry
    {
        public WeaponType Type;
        public Weapon Prefab;

        [Header("Offset in Hand")]
        public Vector3 PositionOffset;
        public Vector3 RotationOffset;
    }

    [SerializeField] private WeaponEntry[] _weapons;

    public WeaponEntry GetWeaponEntry(WeaponType type)
    {
        foreach (var entry in _weapons)
        {
            if (entry.Type == type)
                return entry;
        }

        Debug.LogError($"Weapon of type {type} not found in WeaponContainer!");
        return null;
    }
}
