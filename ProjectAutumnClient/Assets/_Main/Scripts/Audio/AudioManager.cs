using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace CerenityStudio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance { get; private set; }

    #region VARIABLE
        //[field: Header("Music")]
        //[field: SerializeField] public EventReference bgm { get; private set; }

        //[field: Header("SFX")]
        //[field: SerializeField] public EventReference jumpSound { get; private set; }
        //[field: SerializeField] public EventReference enemySound { get; private set; }

    #endregion

    #region UNITY FUNCTION
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance != null)
            {
#if UNITY_EDITOR
                Debug.LogError("Found more than one Audio Manager in the scene");
#endif
            }
            instance = this;
        }

        // void Start()
        // {
        //     PlayerController.onBump += PlayJumpSound;
        // }

        // private void OnDestroy()
        // {
        //     PlayerController.onBump -= PlayJumpSound;
        // }
    #endregion

    #region PUBLIC FUNTION
        public void PlayOneShot(EventReference sound, Vector3 worldPos)
        {
             RuntimeManager.PlayOneShot(sound, worldPos);
        }

        // public void PlayBumpSound()
        // {
        //     //AudioManager.instance.PlayOneShot(FMODEvents.instance.bumpSound, this.transform.position);
        //     PlayOneShot(bumpSound, this.transform.position);
        // }

        // public void PlayMonsterRoar()
        // {
        //     PlayOneShot(enemySound, this.transform.position);
        // }
    #endregion

    #region PRIVATE FUNCTION
    #endregion
    }
}