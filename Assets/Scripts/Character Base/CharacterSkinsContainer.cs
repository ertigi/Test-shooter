using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character Skins Container", menuName = "Character/Skins Container", order = 1)]
public class CharacterSkinsContainer : ScriptableObject
{
    [SerializeField] private CharacterControllerBase _player;
    [SerializeField] private List<CharacterControllerBase> _bots;

    public CharacterControllerBase Player => _player;
    public List<CharacterControllerBase> Bots => _bots;
}
