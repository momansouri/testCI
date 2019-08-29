using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

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

        BuildPipeline.BuildPlayer(buildPlayerOptions);
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