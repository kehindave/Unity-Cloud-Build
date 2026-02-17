using UnityEditor;

public class BuildScript
{
    public static void BuildWindows()
    {
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/Test Scene" },
            "Build/Windows/Game.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}