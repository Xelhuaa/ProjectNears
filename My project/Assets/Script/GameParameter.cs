using System.Collections.Generic;

public static class GameParameter
{
    public static readonly Dictionary<SceneNames, string> sceneNameMap = new Dictionary<SceneNames, string>
    {
        { SceneNames.MainMenu, "MainMenu" },
        { SceneNames.Gameplay, "Gameplay" }
    };
}
