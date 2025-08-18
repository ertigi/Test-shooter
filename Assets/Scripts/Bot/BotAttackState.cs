using UnityEngine;

public class BotAttackState : IBotState
{
    private readonly Bot _bot;
    private readonly Transform _player;

    public BotAttackState(Bot bot, Transform player)
    {
        _bot = bot;
        _player = player;
    }

    public void Enter()
    {
        _bot.Weapon.StartShooting();
    }

    public void Exit()
    {
        _bot.Weapon.StopShooting();
    }

    public void Update()
    {
        if (_player == null) return;

        float distance = Vector3.Distance(_bot.transform.position, _player.position);

        if (distance > _bot.BotSettings.AttackDistance || !_bot.CanSeePlayer(_player))
        {
            _bot.FSM.Enter<BotMovementState>();
            return;
        }
    }
}
