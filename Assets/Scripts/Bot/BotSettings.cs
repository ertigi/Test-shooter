using UnityEngine;

[CreateAssetMenu(fileName = "Bot Settings", menuName = "Bot/Bot Settings", order = 1)]
public class BotSettings : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float AttackDistance { get; private set; }
    [field: SerializeField] public Vector2 MinMaxHealth { get; private set; }
}
