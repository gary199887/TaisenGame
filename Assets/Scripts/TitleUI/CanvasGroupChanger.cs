using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Reflection;
using Unity.VisualScripting;

public class CanvasGroupChanger : MonoBehaviour, Button
{
    [SerializeField]
    CanvasGroup now;

    [SerializeField]
    CanvasGroup next;

    [Range(0,10)]
    [SerializeField]
    float direction;

    [SerializeField]
    Ease nowCvGp;
    [SerializeField]
    Ease nextCvGp;

    [SerializeField]
    AudioClip audioClip;

    [SerializeField]
    AudioSource audioSource;

    public void onClicked()
    {
        audioSource.PlayOneShot(audioClip);
        TitleCursor.canMove = false;
        next.gameObject.SetActive(true);
        now.DOFade(0, direction).SetEase(nowCvGp)
       .OnComplete
       (
            () =>
            {
                next.DOFade(1, direction).SetEase(nextCvGp).OnComplete
                (
                    () =>
                    {
                        now.gameObject.SetActive(false);
                        TitleCursor.canMove = true;
                    }
               );
            }
       );
    }
}
