using UnityEngine;

public class GameLoopState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly CursorService _cursorService;

    public GameLoopState(StateMachine stateMachine, CursorService cursorService)
    {
        _stateMachine = stateMachine;
        _cursorService = cursorService;
    }

    public void Enter()
    {
        _cursorService.Lock();
    }

    public void Exit()
    {

    }
}
