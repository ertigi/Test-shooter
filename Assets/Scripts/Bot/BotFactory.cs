using System.Collections.Generic;
using UnityEngine;

public class BotFactory
{
    private readonly Transform _poolRoot;
    private readonly Stack<Bot> _pool = new();
    private readonly CharacterSkinsContainer _characterSkinsContainer;
    private readonly WeaponFactory _weaponFactory;
    private Transform _player;

    public BotFactory(CharacterSkinsContainer characterSkinsContainer, WeaponFactory weaponFactory)
    {
        _poolRoot = new GameObject("BotPool").transform;
        _characterSkinsContainer = characterSkinsContainer;
        _weaponFactory = weaponFactory;
    }

    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }

    public Bot Get(Vector3 position, Quaternion rotation)
    {
        Bot bot;
        if (_pool.Count > 0)
        {
            bot = _pool.Pop();
            bot.gameObject.SetActive(true);
        }
        else
        {
            bot = Object.Instantiate(_characterSkinsContainer.BotPrafab, position, rotation);
            var skin = Object.Instantiate(_characterSkinsContainer.GetRandomBotSkin());
            bot.Init(skin, _weaponFactory, _player);
        }

        bot.transform.SetParent(_poolRoot);
        bot.transform.SetPositionAndRotation(position, rotation);
        return bot;
    }

    public void Release(Bot bot)
    {
        bot.gameObject.SetActive(false);
        _pool.Push(bot);
    }
}