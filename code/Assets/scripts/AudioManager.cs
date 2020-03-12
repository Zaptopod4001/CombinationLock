using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eses.CombinationLock
{
        
    // Copyright Sami S. 

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    
    // NOTE:
    // Audio class to play audio clips
    // In this case CombinationLock uses
    // this to play button sounds

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip correctPress;
        [SerializeField] AudioClip incorrectPress;
        [SerializeField] AudioClip resetPress;
        [SerializeField] AudioClip done;
        [SerializeField] AudioClip openDoor;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void PlayCorrect()
        {
            audioSource?.PlayOneShot(correctPress);
        }

        public void PlayIncorrect()
        {
            audioSource?.PlayOneShot(incorrectPress);
        }

        public void PlayDone()
        {
            audioSource?.PlayOneShot(done);
        }

        public void PlayReset()
        {
            audioSource?.PlayOneShot(resetPress);
        }

        public void PlayOpen()
        {
            audioSource?.PlayOneShot(openDoor);
        }
    }

}
