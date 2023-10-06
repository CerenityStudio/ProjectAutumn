using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CerenityStudio
{
    public class FadeUI : MonoBehaviour
    {
        public UnityEvent onStartGame;
        
        public void LoadGame()
        {
            onStartGame?.Invoke();
        }
    }
}

