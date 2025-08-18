using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    [SerializeField] private WeaponContainer _weaponContainer;
    [SerializeField] private Bullet _bulletPrefab;

    public override void InstallBindings()
    {
        Container.Bind<WeaponContainer>().FromInstance(_weaponContainer).AsSingle();
        Container.Bind<Bullet>().FromInstance(_bulletPrefab).AsSingle();
    }
}