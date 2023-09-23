/* 
    Cerenity Studio Asset Bundle Loaders C# script for Unity Projects 
    Copyright ©2018 - 2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace CerenityStudio
{
    public class csAssetBundleWebLoader : MonoBehaviour
    {
#region VARIABLES
        [Header(" Asset Bundle Configuration ")]
        [SerializeField] private string bundleUrl = "http://localhost/yourfolder/assetbundlename";
        [SerializeField] private string assetName = "AssetsBundledName";
#endregion
        
#region UNITY FUNCTION
        // Start is called before the first frame update
        IEnumerator Start()
        {
            using(WWW web = new WWW(bundleUrl))
            {
                yield return web;
                AssetBundle remoteAssetBundle = web.assetBundle;
                if(remoteAssetBundle == null)
                {
#if UNITY_EDITOR
                    Debug.LogError("Failed to download AssetBundle!");
#endif
                    yield break;
                }
                Instantiate(remoteAssetBundle.LoadAsset(assetName));
                remoteAssetBundle.Unload(false);
            }
        }
#endregion
    }
}
