using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

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
    
    // public static void BuildMac()
    // {
    //     BuildPipeline.BuildPlayer(
    //         new[] { "Assets/Scenes/Test Scene.unity" },
    //         "build/StandaloneOSX/Game.app",   // match buildsPath in workflow
    //         BuildTarget.StandaloneOSX,
    //         BuildOptions.None
    //     );
    // }
    
    public static void BuildMac()
    {
        // 1. Define build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetEnabledScenes();
        buildPlayerOptions.locationPathName = "build/StandaloneOSX/MyGame.app";
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;

        // 2. Execute the build
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        // 3. Output results for the GitHub Log
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            EditorApplication.Exit(0); // Exit code 0 = Success
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed!");
            EditorApplication.Exit(1); // Exit code 1 = Failure
        }
    }

    private static string[] GetEnabledScenes()
    {
        return System.Array.ConvertAll(EditorBuildSettings.scenes, scene => scene.path);
    }
}