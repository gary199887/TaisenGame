using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEButton : MonoBehaviour,Button
{

    [SerializeField]
    AudioClip audioClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void onClicked()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
