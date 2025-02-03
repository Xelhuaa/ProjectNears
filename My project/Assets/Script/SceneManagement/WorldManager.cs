using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum SceneNames
{
    MainMenu,
    Gameplay,
}

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScene(SceneNames.MainMenu);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(SceneNames sceneName)
    {
        if (GameParameter.sceneNameMap.TryGetValue(sceneName, out string sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
