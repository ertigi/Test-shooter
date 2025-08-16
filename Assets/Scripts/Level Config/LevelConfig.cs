using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Environment Scene")]
    [SerializeField] private SceneReference _environmentScene;

    public string EnvironmentScenePath => _environmentScene.ScenePath;
    public string EnvironmentSceneName => _environmentScene.SceneName;
}
