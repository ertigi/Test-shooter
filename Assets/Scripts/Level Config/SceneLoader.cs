using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void Load(string sceneName, bool additive = false, Action onLoaded = null)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("SceneLoader: sceneName is null or empty!");
            return;
        }

        LoadSceneMode mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName, mode);

        void OnSceneLoaded(Scene scene, LoadSceneMode loadedMode)
        {
            if (scene.name == sceneName)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                onLoaded?.Invoke();
            }
        }
    }

    public void LoadAsync(string sceneName, bool additive = false, Action onLoaded = null)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("SceneLoader: sceneName is null or empty!");
            return;
        }

        LoadSceneMode mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
        var operation = SceneManager.LoadSceneAsync(sceneName, mode);

        if (operation == null)
        {
            Debug.LogError($"SceneLoader: failed to start loading scene {sceneName}");
            return;
        }

        operation.completed += _ => onLoaded?.Invoke();
    }

    public void Unload(string sceneName, Action onUnloaded = null)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            Debug.LogWarning($"SceneLoader: scene {sceneName} is not loaded!");
            onUnloaded?.Invoke();
            return;
        }

        var operation = SceneManager.UnloadSceneAsync(sceneName);
        if (operation != null)
            operation.completed += _ => onUnloaded?.Invoke();
    }
}
