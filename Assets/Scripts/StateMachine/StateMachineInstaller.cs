using Zenject;

public class StateMachineInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var stateMachine = new StateMachine(Container);

        Container.Bind<StateMachine>().FromInstance(stateMachine).AsSingle();

        stateMachine.Enter<BootstrapState>();
    }
}