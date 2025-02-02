using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public enum SceneNames
{
    MainMenu,
    Gameplay,
}

public class PersistentSceneManager : MonoBehaviour
{
    public static PersistentSceneManager Instance;
    private SceneNames currentScene;

    private Dictionary<SceneNames, string> sceneNameMap = new Dictionary<SceneNames, string>
    {
        { SceneNames.MainMenu, "MainMenu" },
        { SceneNames.Gameplay, "Gameplay" }
    };

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

    private void Start()
    {
        currentScene = SceneNames.MainMenu;
    }

    public void LoadScene(SceneNames sceneName)
    {
        if (currentScene != sceneName)
        {
            SceneManager.LoadSceneAsync(sceneNameMap[sceneName], LoadSceneMode.Additive).completed += (asyncOperation) =>
            {
                UnloadScene(currentScene);
                currentScene = sceneName;
            };
        }
    }

    public void UnloadScene(SceneNames sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneNameMap[sceneName], UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }
}
