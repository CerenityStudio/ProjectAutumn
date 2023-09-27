using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CerenityStudio
{
    public class PlayerHide : MonoBehaviour
    {
        public bool isHiding;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Hiding Spot"))
            {
                isHiding = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Hiding Spot"))
            {
                isHiding = false;
            }
        }
    }   
}
