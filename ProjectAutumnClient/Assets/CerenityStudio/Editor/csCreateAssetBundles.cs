/* 
    Cerenity Studio Asset Bundle C# script for Unity Projects 
    Copyright ©2018 - 2023
*/
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CerenityStudio
{
    public class csCreateAssetBundles
    {
#region CUSTOM SCRIPT
        [MenuItem("Cerenity Studio/Tools/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            string assetBundleDirectory = "Assets/StreamingAssets";

            if(!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory,
            BuildAssetBundleOptions.None,
            EditorUserBuildSettings.activeBuildTarget);
        }
#endregion
    }
} 
