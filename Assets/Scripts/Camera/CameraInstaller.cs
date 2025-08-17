using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private CameraContainer _cameraContainer;

    public override void InstallBindings()
    {
        Container.Bind<CameraContainer>().FromInstance(_cameraContainer).AsSingle();
    }
}
