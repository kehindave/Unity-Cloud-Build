using UnityEditor;

public class BuildScript
{
    public static void BuildWindows()
    {
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/Test Scene.unity" },
            "Build/Windows/Game.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
    
    public static void BuildMac()
    {
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/Test Scene.unity" },
            "build/StandaloneOSX/Game.app",   // match buildsPath in workflow
            BuildTarget.StandaloneOSX,
            BuildOptions.None
        );
    }
}