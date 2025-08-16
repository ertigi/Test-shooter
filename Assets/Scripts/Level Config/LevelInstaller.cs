﻿using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelConfig _levelConfig;

    public override void InstallBindings()
    {
        Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
    }
}