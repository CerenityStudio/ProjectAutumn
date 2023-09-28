using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CerenityStudio {
    public class ObjectInteractive : MonoBehaviour
    {
    #region VARIABLE
        public Sprite objSprite;
        public string objTittle;
        public string objDesc;

        [SerializeField] private GameObject _popUpPanel;
        [SerializeField] PanelMemory _memory;
    #endregion 
 

    #region PUBLIC FUNCTION
        //Fungsi yang dipanggil oleh karakter Interactor untuk menspawn memory
        public void PickUp(){
            _memory.memoryImage.sprite = objSprite;
            _memory.memoryTitle.text = objTittle;
            _memory.memoryDesc.text = objDesc;

            Instantiate(_popUpPanel, GameObject.FindObjectOfType<Canvas>().transform);
            Destroy(gameObject, 0.5f);
        }
    #endregion
    }
}
