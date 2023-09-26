using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkSystemManager : MonoBehaviour
{
    public GameObject talkSystem;
    DialogManager dialogManager;            // dialog manager for openning control
    public static List<Chara> charaList;    // charaList for the stage, be set in GameDirector(after loading data from file)
    public static int currentChosen;        // index of the chara chosen currently
    public Text[] charaDetailText;          // UI components, 0:name  1:gender  2:relationShip  3:secret
    float timeCount;                        // timeCounter
    const float cd = 0.2f;                  // gap between two actions(prevent making multiple actions by the same key-down)
    public static bool choosingQuestion;
    int currentQuestion;
    string[][] questions;
    [SerializeField] AudioSource[] SE;       // 0: cancel, 1: change selection
    [SerializeField] SpriteRenderer charaImage;
    [SerializeField] Sprite[] charaSprites;
    Vector3 charaImageScale;
    private void Start()
    {
        // clear timer and initialize data when scene loaded
        currentChosen = 0;
        talkSystem.SetActive(false);
        timeCount = 0;
        dialogManager = gameObject.GetComponent<DialogManager>();
        charaImageScale = charaImage.gameObject.transform.localScale;
        choosingQuestion = false;
        currentQuestion = 0;
        questions = new string[3][];
        questions[0] = new string[] { "身元を聞く" };
        questions[1] = new string[] { "アリバイを聞く" };
        questions[2] = new string[] { "アイテムについて聞く" };
    }

    // Update is called once per frame
    void Update()
    {
        if (!talkSystem.activeSelf) return;     // do nothing when talk system is not active
        
        // can do some actions only if talk system is active
        timeCount += Time.deltaTime;
        if (timeCount > cd)  // to make a gap between choice changed or other actions
        {
            if(!dialogManager.dialog.activeSelf)
            if (Input.GetAxis("Horizontal") > 0.1)  // get next chara
            {
                if(!choosingQuestion)
                           startTalk(currentChosen == charaList.Count - 1 ? currentChosen = 0 : ++currentChosen);
                else 
                           dialogManager.showDialog(questions[currentQuestion == questions.Length -1 ? currentQuestion = 0 : ++currentQuestion]);
                SE[1].Play();
                timeCount = 0;  // clear counter when whatever actions had been taken
            }
            else if (Input.GetAxis("Horizontal") < -0.1)
            {
                    if (!choosingQuestion)
                        startTalk(currentChosen == 0 ? currentChosen = charaList.Count - 1 : --currentChosen);
                    else dialogManager.showDialog(questions[currentQuestion == 0? currentQuestion = questions.Length - 1 : --currentQuestion]);
                SE[1].Play();
                timeCount = 0;
            }
            else if (Input.GetButtonDown("Cancel"))  // move back to detect part
            {
                    if (!choosingQuestion)
                    {
                        PlayerController.canMove = true;
                        talkSystem.SetActive(false);
                    }
                    timeCount = 0;
                    SE[0].Play();
                }
            else if (Input.GetButtonDown("Submit"))  // talk with chosen charactor
            {
                timeCount = 0;
                    if (!choosingQuestion)
                    {
                        choosingQuestion = true;
                        dialogManager.showDialog(questions[currentQuestion]);
                    }
                    else
                    {
                        Chara chara = charaList[currentChosen];
                     //choose ques
                          
                                dialogManager.showDialog(chara.talks.normalTalk[0].talks);
                        
                    }
                    // throw the talk array(string[]) of current chosen charactor to dialog system
            }
        } 
    }

    // start talk system
    public void startTalk(int choose) {
        PlayerController.canMove = false;   // make player connot do any action
        Chara chara = charaList[choose];

        // set charactor detail to text UI
        charaDetailText[0].text = chara.name; 
        charaDetailText[1].text = $"性別：{chara.gender}";
        charaDetailText[2].text = $"人間関係：\n{chara.relationShip}";
        charaDetailText[3].text = $"秘密：\n{chara.secret}";

        changeCharaImage(chara);
        // clear timer
        timeCount = 0;
        // then start talk system
        talkSystem.SetActive(true);
    }

    // switch character image up to chara's gender 
    void changeCharaImage(Chara chara)
    {
        if (chara.gender.Equals("男")) { 
            charaImage.sprite = charaSprites[0];
            charaImage.gameObject.transform.localScale = charaImageScale;
        }
        else
        {
            charaImage.sprite = charaSprites[1];
            charaImage.gameObject.transform.localScale = charaImageScale * 0.8f;
        }
    }
}
