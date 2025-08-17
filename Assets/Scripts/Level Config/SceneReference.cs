using System;
using UnityEngine;

[Serializable]
public class SceneReference
{
    [SerializeField] private string _scenePath;

    public string ScenePath => _scenePath;

#if UNITY_EDITOR
    public string SceneName
    {
        get
        {
            if (string.IsNullOrEmpty(_scenePath))
                return string.Empty;

            return System.IO.Path.GetFileNameWithoutExtension(_scenePath);
        }
    }
#endif
}