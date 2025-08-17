using UnityEngine;
using Zenject;

public class CharactersInstaller : MonoInstaller
{
    [SerializeField] private CharacterSkinsContainer _skinContainer;

    public override void InstallBindings()
    {
        Container.Bind<CharacterSkinsContainer>().FromInstance(_skinContainer).AsSingle();
    }
}
