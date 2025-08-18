public class BotRespawnState : IBotState
{
    private readonly Bot _bot;

    public BotRespawnState(Bot bot) => _bot = bot;

    public void Enter()
    {
        _bot.Respawn();
    }

    public void Update()
    {
        if (_bot.CharacterController.Skin.Animator.IsAnimationDieFinished())
            _bot.FSM.Enter<BotMovementState>();
    }

    public void Exit() { }
}
