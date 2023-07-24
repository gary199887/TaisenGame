using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class StageChangeButton : MonoBehaviour,Button
{
    [SerializeField]
    int stageNum;

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
        Invoke("InvokeExecute", 0.2f);
    }

    void InvokeExecute()
    {
        GameDirector.stage = stageNum;
        SceneManager.LoadScene("GameScene");
    }
}
