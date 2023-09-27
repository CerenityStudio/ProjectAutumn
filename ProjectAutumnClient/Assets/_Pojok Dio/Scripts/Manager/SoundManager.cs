using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CerenityStudio
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        public void PlaySound(AudioClip clip)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}

