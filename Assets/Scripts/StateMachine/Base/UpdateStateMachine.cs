public class UpdateStateMachine : StateMachineBase
{
    public override void Enter<TState>()
    {
        base.Enter<TState>();
    }

    public virtual void Update()
    {
        if (_activeState is IUpdateState)
        {
            (_activeState as IUpdateState).Update();
        }
    }

    public virtual void FixedUpdate()
    {
        if (_activeState is IFixedUpdateState)
        {
            (_activeState as IFixedUpdateState).FixedUpdate();
        }
    }

    public virtual void LateUpdate()
    {
        if (_activeState is ILateUpdateState)
        {
            (_activeState as ILateUpdateState).LateUpdate();
        }
    }
}