using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CerenityStudio
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip catSound;
        
        private void Update()
        {
            Meow();
        }

        void Meow ()
        {
            
            if (Input.GetKeyDown(KeyCode.E))
                Debug.Log("Meoww");
        }
    }
}
