/* 
    Cerenity Studio Safe Area C# script for Unity Projects 
    Copyright ©2018 - 2023
*/
using UnityEngine;

namespace CerenityStudio
{
    public class csSafeArea : MonoBehaviour
    {
#region VARIABLE
        RectTransform rectTransform;
        Rect safeArea;
        Vector2 minAnchor;
        Vector2 maxAnchor;
#endregion

#region UNITY SCRIPT
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            safeArea = Screen.safeArea;
            minAnchor = safeArea.position;
            maxAnchor = minAnchor + safeArea.size;

            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAnchor.x /= Screen.width;
            maxAnchor.y /= Screen.height;

            rectTransform.anchorMin = minAnchor;
            rectTransform.anchorMax = maxAnchor;
        }
#endregion
    }
}

