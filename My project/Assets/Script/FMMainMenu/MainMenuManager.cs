using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private UIMainMenu uiMainMenuPrefab;
    void Start()
    {
        if (uiMainMenuPrefab != null)
        {
            Instantiate(uiMainMenuPrefab, transform).Initialize();
        }
    }
}
