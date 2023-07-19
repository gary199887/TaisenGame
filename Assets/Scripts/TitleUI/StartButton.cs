using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartButton : MonoBehaviour, Button
{
    [SerializeField]
    CanvasGroup menuUI;

    [Range(0,1)]
    [SerializeField]
    float fadeSpeed;

    CanvasGroup thisUI;
    private void Start()
    {
        thisUI=this.transform.parent.GetComponent<CanvasGroup>();
    }
    public void onClicked()
    {
        thisUI.DOFade(0,fadeSpeed)
       .OnComplete
       (
            () =>
            {
                menuUI.gameObject.SetActive(true);
                menuUI.DOFade(1, fadeSpeed);
            }
       );
        thisUI.gameObject.SetActive(false);
    }
}
