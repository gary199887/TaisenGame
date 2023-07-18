using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Slide : MonoBehaviour,Button
{ 
    CanvasGroup cvgp;

    [SerializeField]
    float direction;

    private void Start()
    {
        cvgp = GetComponent<CanvasGroup>();
    }

    public void onClicked()
    {

    }
    
    void Out()
    {
        cvgp.DOFade(0.0f, direction);
    }

    private void In()
    {
        cvgp.DOFade(1.0f, direction);
    }
}
