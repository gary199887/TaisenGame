using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialog;
    public Text dialogText;
    TalkSystemManager talkSystemManager;
    float timeCount;
    const float cd = 0.1f;
    string[] talks;
    int currentIndex;


    private void Start()
    {
        timeCount = 0;
        dialog.SetActive(false);
        currentIndex = 0;
        talkSystemManager = gameObject.GetComponent<TalkSystemManager>();
    }

    private void Update()
    {
        if (!dialog.activeSelf) return;
        timeCount += Time.deltaTime;
        if (currentIndex < talks.Length - 1)
        {
            if (Input.GetKeyDown(KeyCode.Z) && timeCount > cd)
            {
                currentIndex++;
                dialogText.text = talks[currentIndex] + "Б@Бе";
                timeCount = 0;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && timeCount > cd)
            {
                timeCount = 0;
                currentIndex = 0;
                dialog.SetActive(false);
                talkSystemManager.startTalk(TalkSystemManager.currentChosen);
            }
        }
    }
    public void showDialog(string[] talks) {
        if (currentIndex >= talks.Length) return;
        this.talks = talks;
        dialog.SetActive(true);
        dialogText.text = this.talks[currentIndex] + "Б@Бе";
    }
}
