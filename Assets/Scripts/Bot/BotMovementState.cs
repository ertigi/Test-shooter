using UnityEngine;

public class BotMovementState : IBotState
{
    private readonly Bot _bot;
    private readonly Transform _player;

    public BotMovementState(Bot bot, Transform player)
    {
        _bot = bot;
        _player = player;
    }

    public void Enter()
    {
        _bot.SetDestination(_player.position);
    }

    public void Exit()
    {
        _bot.SetDestination(_bot.transform.position);
    }

    public void Update()
    {
        float distance = Vector3.Distance(_bot.transform.position, _player.position);

        if (distance <= _bot.BotSettings.AttackDistance && _bot.CanSeePlayer(_player))
        {
            _bot.FSM.Enter<BotAttackState>();
            return;
        }
    }
}
