using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character Skins Container", menuName = "Character/Skins Container", order = 1)]
public class CharacterSkinsContainer : ScriptableObject
{
    [SerializeField] private CharacterControllerBase _player;
    [SerializeField] private List<CharacterSkin> _bots;
    [SerializeField] private Bot _botPrafab;

    public CharacterControllerBase Player => _player;
    public List<CharacterSkin> Bots => _bots;
    public Bot BotPrafab => _botPrafab;

    public CharacterSkin GetRandomBotSkin()
    {
        int rand = Random.Range(0, _bots.Count);
        return _bots[rand];
    }
}
