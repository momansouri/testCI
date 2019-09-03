using System.Linq;
using UnityEditor;

public class BuildScript
{
    public static void Android()
    {
        var buildPlayerOptions = new BuildPlayerOptions
        {
            locationPathName = @"c:\temp\mmansouri.apk",
            options = BuildOptions.AllowDebugging,
            target = BuildTarget.Android,
            targetGroup = BuildTargetGroup.Android,
            scenes = GetScenes()            
        };

        string buildResult = BuildPipeline.BuildPlayer(buildPlayerOptions);

        if (buildResult.Length > 0)
            throw new System.Exception($"Build error: {buildResult}");
    }

    public static void Package()
    {
        AssetDatabase.ExportPackage(@"Assets\Scenes", "mmansouri.unitypackage", ExportPackageOptions.Default);
    }
    private static string[] GetScenes()
    {
        return EditorBuildSettings.scenes
            .Where(s => s.enabled)
            .Select(s => s.path)
            .ToArray();
    }
}