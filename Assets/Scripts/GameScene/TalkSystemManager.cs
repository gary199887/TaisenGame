using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSystemManager : MonoBehaviour
{
    public GameObject talkSystem;
    DialogManager dialogManager;
    public static List<Chara> charaList;
    public static int currentChosen;
    public Text[] charaDetailText;
    float timeCount;
    const float cd = 0.2f;
    private void Start()
    {
        currentChosen = 0;
        talkSystem.SetActive(false);
        timeCount = 0;
        dialogManager = gameObject.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!talkSystem.activeSelf) return;
        timeCount += Time.deltaTime;
        if (timeCount > cd)  //to make a gap between choice changed or other actions
        {
            if (Input.GetAxis("Horizontal") > 0.1)  // get next chara
            {
                startTalk(currentChosen == charaList.Count - 1 ? currentChosen = 0 : ++currentChosen);
                timeCount = 0;
            }
            else if (Input.GetAxis("Horizontal") < -0.1)
            {
                startTalk(currentChosen == 0 ? currentChosen = charaList.Count - 1 : --currentChosen);
                timeCount = 0;
            }
            else if (Input.GetKeyDown(KeyCode.X))  //move back to detect part
            {
                PlayerController.canMove = true;
                timeCount = 0;
                talkSystem.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Z))  //talk with chosen charactor
            {
                timeCount = 0;
                dialogManager.showDialog(charaList[currentChosen].talks);
            }
        } 
    }

    public void startTalk(int choose) {
        PlayerController.canMove = false;
        Chara chara = charaList[choose];
        charaDetailText[0].text = chara.name; 
        charaDetailText[1].text = $"性別：{chara.gender}";
        charaDetailText[2].text = $"人間関係：\n{chara.relationShip}";
        charaDetailText[3].text = $"秘密：\n{chara.secret}";
        timeCount = 0;
        talkSystem.SetActive(true);
    }
}
