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
    float duration;

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
        now.DOFade(0, duration).SetEase(nowCvGp).
            OnComplete(() =>
            {
                now.gameObject.SetActive(false);
                next.gameObject.SetActive(true);
                next.DOFade(1, duration).SetEase(nextCvGp).SetLink(gameObject);
            });
    }
}
