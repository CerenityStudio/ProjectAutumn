using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace CerenityStudio
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private EventReference catSound;
        
        private void Update()
        {
            Meow();
        }

        private void Meow ()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayOneShot(catSound, this.transform.position);
                Debug.Log("Meoww");
            }
                
        }
    }
}
