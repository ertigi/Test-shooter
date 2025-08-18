public class BotDieState : IBotState
{
    private readonly Bot _bot;
    public bool IsFinished { get; private set; }

    public BotDieState(Bot bot) => _bot = bot;

    public void Enter()
    {
        _bot.CharacterController.Skin.Animator.Die();
        IsFinished = false;
    }

    public void Exit() 
    {
        
    }

    public void Update()
    {
        if (_bot.CharacterController.Skin.Animator.IsAnimationDieFinished())
            IsFinished = true;
    }
}
