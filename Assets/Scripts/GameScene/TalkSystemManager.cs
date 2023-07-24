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
    [SerializeField]AudioSource[] SE;       // 0: cancel, 1: change selection
    private void Start()
    {
        // clear timer and initialize data when scene loaded
        currentChosen = 0;
        talkSystem.SetActive(false);
        timeCount = 0;
        dialogManager = gameObject.GetComponent<DialogManager>();
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
                startTalk(currentChosen == charaList.Count - 1 ? currentChosen = 0 : ++currentChosen);
                SE[1].Play();
                timeCount = 0;  // clear counter when whatever actions had been taken
            }
            else if (Input.GetAxis("Horizontal") < -0.1)
            {
                startTalk(currentChosen == 0 ? currentChosen = charaList.Count - 1 : --currentChosen);
                SE[1].Play();
                timeCount = 0;
            }
            else if (Input.GetButtonDown("Cancel"))  // move back to detect part
            {
                PlayerController.canMove = true;
                timeCount = 0;
                SE[0].Play();
                talkSystem.SetActive(false);
            }
            else if (Input.GetButtonDown("Submit"))  // talk with chosen charactor
            {
                timeCount = 0;
                dialogManager.showDialog(charaList[currentChosen].talks);   // throw the talk array(string[]) of current chosen charactor to dialog system
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
        
        // clear timer
        timeCount = 0;
        // then start talk system
        talkSystem.SetActive(true);
    }
}
