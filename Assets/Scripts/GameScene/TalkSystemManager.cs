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
    public static bool choosingQuestion;    // whether is choosing question or not
    int currentQuestion;                    // current selected question id
    string[] questions;                     // question string array
    int[] normalTime;                       // times to talk with charas, index->charaId
    [SerializeField] public GameObject questionUI;
    [SerializeField] public Text questionText;
    [SerializeField] AudioSource[] SE;       // 0: cancel, 1: change selection
    [SerializeField] SpriteRenderer charaImage;
    [SerializeField] Sprite[] charaSprites;
    [SerializeField] public ItemBoxUIManager itemBoxUIManager;

    Vector3 charaImageScale;
    private void Start()
    {
        // clear timer and initialize data when scene loaded
        currentChosen = 0;
        talkSystem.SetActive(false);
        timeCount = 0;
        dialogManager = gameObject.GetComponent<DialogManager>();
        charaImageScale = charaImage.gameObject.transform.localScale;

        // question system initialize
        choosingQuestion = false;
        currentQuestion = 0;
        questions = new string[4];
        questions[0] = new string("証言を聞く");
        questions[1] = new string("アリバイを聞く");
        questions[2] = new string("アイテムについて聞く");
        questions[3] = charaList[currentChosen].talks.qa.question;
        normalTime = new int[charaList.Count];
        for (int i = 0; i < normalTime.Length; ++i)
            normalTime[i] = 0;
        closeQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!talkSystem.activeSelf) return;     // do nothing when talk system is not active
        
        // can do some actions only if talk system is active
        timeCount += Time.deltaTime;
        if (timeCount > cd)  // to make a gap between choice changed or other actions
        {
            if(!dialogManager.dialog.activeSelf && !itemBoxUIManager.itemBoxUI.activeSelf)
            if (Input.GetAxis("Horizontal") > 0.1)  // get next chara or question
            {
                    if (!choosingQuestion)
                    {
                        startTalk(currentChosen == charaList.Count - 1 ? currentChosen = 0 : ++currentChosen);
                        questions[3] = charaList[currentChosen].talks.qa.question;
                    }
                    else
                    {
                        showQuestion(questions[currentQuestion == questions.Length - 1 ? currentQuestion = 0 : ++currentQuestion]);
                        if (currentQuestion == questions.Length - 1)
                        {
                            Trigger trigger = charaList[currentChosen].talks.qa.trigger;
                            if (normalTime[trigger.charaId] < trigger.normalTimes)   // set limitation if certain chara hasn't said the words
                                showQuestion(questions[currentQuestion == questions.Length - 1 ? currentQuestion = 0 : ++currentQuestion]);     // skip this question
                        }
                    }
                SE[1].Play();
                timeCount = 0;  // clear counter when whatever actions had been taken
            }
            else if (Input.GetAxis("Horizontal") < -0.1)
            {
                    if (!choosingQuestion)
                    {
                        startTalk(currentChosen == 0 ? currentChosen = charaList.Count - 1 : --currentChosen);
                        questions[3] = charaList[currentChosen].talks.qa.question;
                    }
                    else
                    {
                        showQuestion(questions[currentQuestion == 0 ? currentQuestion = questions.Length - 1 : --currentQuestion]);
                        if (currentQuestion == questions.Length - 1)
                        {
                            Trigger trigger = charaList[currentChosen].talks.qa.trigger;
                            if (normalTime[trigger.charaId] < trigger.normalTimes)   // set limitation if certain chara hasn't said the words
                                showQuestion(questions[currentQuestion == 0 ? currentQuestion = questions.Length - 1 : --currentQuestion]);     // skip this question
                        }
                    }
                    SE[1].Play();
                timeCount = 0;
            }
            else if (Input.GetButtonDown("Cancel"))  // move back to detect part
            {
                    if (!choosingQuestion)
                    {
                        PlayerController.canMove = true;
                        talkSystem.SetActive(false);
                        currentChosen = 0;
                    }
                    else {
                        closeQuestion();
                        choosingQuestion = false;
                        currentQuestion = 0;
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
                        showQuestion(questions[currentQuestion]);
                    }
                    else
                    {
                        Chara chara = charaList[currentChosen];

                        //choosen ques
                        if (currentQuestion == 0)   // normal talk
                        {
                            int id = normalTime[currentChosen];
                            if(normalTime[currentChosen] >= chara.talks.normalTalk.Count)
                                id = chara.talks.normalTalk.Count - 1;
                            dialogManager.showDialog(chara.talks.normalTalk[id].talks);
                            normalTime[currentChosen]++;
                        }
                        else if (currentQuestion == 1)  // alibi talk
                            dialogManager.showDialog(chara.talks.alibi);
                        else if (currentQuestion == 2)  // open itembox
                            itemBoxUIManager.showItemBox();
                        else if (currentQuestion == 3)
                            dialogManager.showDialog(chara.talks.qa.answer);
                    }
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

    void showQuestion(string ques) {
        questionUI.SetActive(true);
        questionText.text = ques;
    }

    void closeQuestion() {
        questionUI.SetActive(false);
    }

    public void showItemTalk(int itemId) {
        string[] itemTalk = charaList[currentChosen].talks.itemTalk[itemId].talks;
        if (itemTalk.Length == 0)
            itemTalk = new string[] {"聞けることがなさそうだ"};
        dialogManager.showDialog(itemTalk);
    }
}
