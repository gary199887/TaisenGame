using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonButton : MonoBehaviour,Button
{
    [SerializeField]
    AudioClip audioClip;

    [SerializeField]
    AudioSource audioSource;
    public void onClicked()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        if(!audioSource.isPlaying)
        {
            audioSource.clip = null;
        }
    }

    
}
