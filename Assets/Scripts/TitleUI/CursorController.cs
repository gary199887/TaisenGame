using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using System.Diagnostics.Tracing;
using UnityEditor;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    Ease ease;
    [SerializeField]
    Transform[] tfrm;
    Image image;
    int index;

    bool isMove;
    bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        index = 0;
        image.transform.position = tfrm[0].position;
        image.DOFade(0, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        isMove = true;
        isUp = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        check(isUp);
        move(isMove);
    }

    Button button;
    Vector3 nowButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            button = collision.gameObject.GetComponent<Button>();
            nowButton = collision.gameObject.transform.position;
            Debug.Log(collision.gameObject.name);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            isUp = true;
        }
    }

    void move(bool isMove)
    {
        if(!isMove) { return; }
        //縦の条件
        //ページがtitleであること
        //横の条件　それ以外

        float input=0;
        if (this.gameObject.transform.parent.name=="Title")
        {
            //縦ボタン有効
            if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.UpArrow))
            {
                input = -1;
            }
            if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow))
            {
                input = 1;
            }
        }
        else
        {
            //横ボタン有効
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                input = 1;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                input = -1;
            }
        }

        if(input>0)
        {
            if (nowButton == tfrm[index].position&&index+1<tfrm.Length)
            {
                image.transform.position = tfrm[index+1].position;
            }
        }
        else if(input>0) 
        {
            if(nowButton == tfrm[index].position&& index-1>0)
            {
                image.transform.position = tfrm[index - 1].position;
            }
        }


    }

    void check(bool isUp)
    {
        if(isUp&&Input.GetButtonUp("Submit"))
        {
            button.onClicked();
        }
    }
}
