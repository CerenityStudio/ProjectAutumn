using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CerenityStudio
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject catSound;
        
        private void Update()
        {
            Meow();
        }

        void Meow ()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                catSound.SetActive(true);
                Debug.Log("Meoww");
                Invoke("DisableCatSound", 2);
            }
                
        }

        void DisableCatSound()
        {
            catSound.SetActive(false);
        }
    }
}
