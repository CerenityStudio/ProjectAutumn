/* 
    Cerenity Studio Build Version Manager C# script for Unity Projects 
    Copyright ©2018 - 2023
*/
using UnityEngine;
using TMPro;

namespace CerenityStudio
{
    public class csBuildManager : MonoBehaviour
    {
#region VARIABLE
        [Header(" Configuration ")]
        [SerializeField] private TextMeshProUGUI versionNumberBuild;
        [SerializeField] private string buildVersion = "your_version_number_here";
#endregion

#region UNITY FUNCTION
        // Start is called before the first frame update
        void Start()
        {
#if UNITY_STANDALONE_WIN
            versionNumberBuild.text = "v" + buildVersion + "_windows";
#endif

#if UNITY_STANDALONE_OSX
            versionNumberBuild.text = "v" + buildVersion + "_macos";
#endif

#if UNITY_WEBGL
            versionNumberBuild.text = "v" + buildVersion + "_webgl";
#endif

#if UNITY_ANDROID
            versionNumberBuild.text = "v" + buildVersion + "_android";
#endif

#if UNITY_IOS
            versionNumberBuild.text = "v" + buildVersion + "_ios";
#endif

#if UNITY_EDITOR
        Debug.Log(versionNumberBuild.text);
#endif
        }
#endregion
    }
}
