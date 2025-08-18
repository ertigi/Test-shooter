using System.Collections.Generic;
using UnityEngine;

public class BotController : IUpdateService
{
    private readonly BotFactory _botFactory;
    private readonly List<Bot> _activeBots = new();
    private readonly List<Transform> _spawnPoints;

    public BotController(BotFactory botFactory)
    {
        _botFactory = botFactory;
    }

    public void SpawnBots(int count)
    {
        for (int i = 0; i < count && i < _spawnPoints.Count; i++)
        {
            //var spawnPoint = _spawnPoints[i];
            var bot = _botFactory.Get(Vector3.zero, Quaternion.identity);
            bot.FSM.Enter<BotRespawnState>();
            _activeBots.Add(bot);
        }
    }

    public void OnUpdate()
    {
        for (int i = _activeBots.Count - 1; i >= 0; i--)
        {
            var bot = _activeBots[i];
            bot.FSM.Update();

            if (bot.Health <= 0 && !(bot.FSM.CurrentState is BotDieState))
            {
                bot.FSM.Enter<BotDieState>();
            }

            if (bot.FSM.CurrentState is BotDieState dieState && dieState.IsFinished)
            {
                _activeBots.RemoveAt(i);
                _botFactory.Release(bot);
            }
        }
    }
}
