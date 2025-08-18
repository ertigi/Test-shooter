using UnityEngine;

public class WeaponFactory
{
    private readonly WeaponContainer _weaponDatabase;
    private readonly BulletService _bulletService;

    public WeaponFactory(WeaponContainer weaponDatabase, BulletService bulletService)
    {
        _weaponDatabase = weaponDatabase;
        _bulletService = bulletService;
    }

    public Weapon CreateWeapon(WeaponType type, Transform parent)
    {
        var entry = _weaponDatabase.GetWeaponEntry(type);

        Weapon weapon = Object.Instantiate(entry.Prefab, parent);
        weapon.Init(_bulletService);

        weapon.transform.localPosition = entry.PositionOffset;
        weapon.transform.localRotation = Quaternion.Euler(entry.RotationOffset);

        return weapon;
    }
}
