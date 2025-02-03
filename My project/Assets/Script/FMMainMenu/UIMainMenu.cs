using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public void Initialize()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        WorldManager.Instance.LoadScene(SceneNames.Gameplay);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
