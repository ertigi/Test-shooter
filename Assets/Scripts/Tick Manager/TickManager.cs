using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TickManager : MonoBehaviour
{
    private readonly List<IUpdateService> _updateServices = new();
    private readonly List<IFixedUpdateService> _fixedUpdateServices = new();
    private readonly List<ILateUpdateService> _lateUpdateServices = new();

    [Inject]
    public void Init(
        IUpdateService[] updateServices,
        IFixedUpdateService[] fixedUpdateServices,
        ILateUpdateService[] lateUpdateServices)
    {
        _updateServices.AddRange(updateServices);
        _fixedUpdateServices.AddRange(fixedUpdateServices);
        _lateUpdateServices.AddRange(lateUpdateServices);
    }

    public void AddService(object service)
    {
        if (service is IUpdateService updateService && !_updateServices.Contains(updateService))
            _updateServices.Add(updateService);

        if (service is IFixedUpdateService fixedService && !_fixedUpdateServices.Contains(fixedService))
            _fixedUpdateServices.Add(fixedService);

        if (service is ILateUpdateService lateService && !_lateUpdateServices.Contains(lateService))
            _lateUpdateServices.Add(lateService);
    }

    public void RemoveService(object service)
    {
        if (service is IUpdateService updateService)
            _updateServices.Remove(updateService);

        if (service is IFixedUpdateService fixedService)
            _fixedUpdateServices.Remove(fixedService);

        if (service is ILateUpdateService lateService)
            _lateUpdateServices.Remove(lateService);
    }

    private void Update()
    {
        for (int i = 0; i < _updateServices.Count; i++)
            _updateServices[i].OnUpdate();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _fixedUpdateServices.Count; i++)
            _fixedUpdateServices[i].OnFixedUpdate();
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _lateUpdateServices.Count; i++)
            _lateUpdateServices[i].OnLateUpdate();
    }
}
