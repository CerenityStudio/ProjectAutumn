using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CerenityStudio{

    public class PanelMemory : MonoBehaviour
    {
    #region VARIABLE
        public Image memoryImage;
        public Text memoryTitle;
        public Text memoryDesc;

        [SerializeField] private Animator _panelAnimation;
    #endregion

    #region UNITY FUNCTION
        private void Start()
        {
            _panelAnimation = GetComponent<Animator>();
        }
    #endregion

    #region PUBLIC FUNCTION
        // Untuk button close pada panel memory
        public void ClosePanel(){
            _panelAnimation.SetTrigger("ClosePanel");
            Destroy(gameObject, 0.5f);
        }
    #endregion
    }
}
