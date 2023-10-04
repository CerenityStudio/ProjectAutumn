using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace CerenityStudio{
    public class Interactor : MonoBehaviour
    {
    #region VARIABLE
        private bool _allowedToPickup;

        ObjectInteractive _object;
    #endregion

    #region PUBLIC FUNCTION
        //Input untuk mem-pickup item dan menampilkan panel
        public void Interactive(InputAction.CallbackContext context){
            if(context.performed && _allowedToPickup){
                _object.PickUp();
            }
        }
    #endregion

    #region PRIVATE FUNCTION
        //Untuk mendeteksi object yang dapat di interaksi
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Object")){
                _allowedToPickup = true;
                _object = other.GetComponent<ObjectInteractive>();
            }
        }
        // Keluar dari objek yang dapat di interaksi
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Object")){
                _allowedToPickup = false;
            }
        }
    #endregion
    }
}
