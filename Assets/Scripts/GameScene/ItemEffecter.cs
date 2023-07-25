using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemEffecter : MonoBehaviour
{
    SpriteRenderer sprd;

    [SerializeField]
    Ease ease;
    [SerializeField]
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        sprd = GetComponent<SpriteRenderer>();
        sprd.DOFade(0, direction).SetLoops(-1, LoopType.Yoyo);    
    }

    
}
