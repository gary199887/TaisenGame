using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] StageQuestionData[] stage;                 // �X�e�[�W���f�[�^
    [SerializeField] Text[] questionText;                       // ��蕶�e�L�X�g
    [SerializeField] UnityEngine.UI.Button[] selAnsButtons;     // �I�����{�^��
    [SerializeField] Text ansCntText;                           // �𓚉\�񐔃e�L�X�g
    [SerializeField] GameDirector gameDirector;
    [SerializeField] AudioSource clickSE;
    [SerializeField] CanvasGroup QAndA;

    const int maxAnsCnt = 3;                        // �ő�𓚉\��
    private int currentAnsCnt;                      // ���݂̉𓚉\��
    
    List<bool> isCorrectAnswer = new List<bool>();  // �𓚐��딻�胊�X�g
    private int currentQNum;                        // ���݂̖��ԍ�

    private int stageNum;                           // �X�e�[�W�ԍ�
    

    private void Start()
    {
        answerSystem.SetActive(false);
        selAnsButtons[0].Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
        stageNum = GameDirector.stage - 1;    // �X�e�[�W�ԍ����擾
        QAndA.alpha = 0.0f;
        foreach (var button in selAnsButtons) button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!answerSystem.activeSelf) return;     

        if (Input.GetButtonDown("Submit"))
        {
            if (!(GameDirector.gameClear || GameDirector.gamePause || GameDirector.gameOver)) 
            clickSE.Play();
        }
    }

    // �𓚊J�n
    public void StartAnswer()
    {
        PlayerController.canMove = false;   // make player connot do any action

        // �𓚉\�����e�L�X�g�ɐݒ�
        ansCntText.text = "�𓚉\�񐔁F" + currentAnsCnt + "/" + maxAnsCnt;

        // ���E�𓚕���ݒ�
        currentQNum = 0;
        SetQAText(currentQNum);

        answerSystem.SetActive(true);
    }

    // �𓚑I��
    public void ClickAnswer(int selectNum)
    {
        // ���딻��i�X�e�[�W�Ή��j
        if (stage[stageNum].Questions[currentQNum].CorrectAnswer ==
            stage[stageNum].Questions[currentQNum].SelectAnswer[selectNum])
        {
            isCorrectAnswer.Add(true);
        }
        else
        {
            isCorrectAnswer.Add(false);
        }

        foreach (var button in selAnsButtons) button.interactable = false;
        ++currentQNum;
        // �S��𓚂������`�F�b�N
        if (currentQNum == stage[stageNum].Questions.Length)
        {
            // �𓚏I��
            EndAnswer();
        }
        else
        {
            // ���̖���
            QAndA.DOFade(0.0f, 0.3f).OnComplete(() => SetQAText(currentQNum));
        }
    }

    // ���E�𓚕���ݒ�
    private void SetQAText(int currentQNum)
    {
        QAndA.DOFade(1.0f, 0.3f).OnComplete(() =>
        {
            foreach(var button in selAnsButtons) button.interactable = true;
        });
        // ��蕶���e�L�X�g�ɐݒ�
        questionText[0].text = "Q." + stage[stageNum].Questions[currentQNum].QNum;
        questionText[1].text = stage[stageNum].Questions[currentQNum].QSentence;

        // ��x�I�����{�^����S��\���ɂ���
        for (int i = 0; i < selAnsButtons.Length; i++)
        {
            selAnsButtons[i].gameObject.SetActive(false);
        }

        // �I�����̐����擾
        int selAnsNum = stage[stageNum].Questions[currentQNum].SelectAnswer.Length;
        // �I�����̐������{�^����\���A�e�L�X�g��ݒ�
        for (int i = 0; i < selAnsNum; i++)
        {
            selAnsButtons[i].gameObject.SetActive(true);
            var selectAnswerText = selAnsButtons[i].GetComponentInChildren<Text>();
            selectAnswerText.text = stage[stageNum].Questions[currentQNum].SelectAnswer[i];
        }
        
        // �I�����{�^���̈ʒu��ݒ�
        SetAnsButtonPos(selAnsNum);

        selAnsButtons[0].Select();
    }

    // �I�����{�^���̈ʒu�ݒ�
    private void SetAnsButtonPos(int selAnsNum)
    {
        // �I�����̐���3�Ȃ�
        if (selAnsNum == 3)
        {
            for (int i = 0; i < selAnsNum; i++)
            {
                selAnsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -200 * i);
            }
        }
        else
        {
            for (int i = 0; i < selAnsNum; i++)
            {
                selAnsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(400 * ((i % 2) * 2 - 1), -100 - (200 * (i / 2)));
            }
        }
    }

    // �𓚏I��
    private void EndAnswer()
    {
        // �s�������܂܂�Ă��邩�`�F�b�N
        if (isCorrectAnswer.Contains(false))
        {
            // �𓚌��������炷
            currentAnsCnt--;
            // �𓚌������e�L�X�g�ɐݒ�
            ansCntText.text = "�𓚉\�񐔁F" + currentAnsCnt + "/" + maxAnsCnt;
            if (currentAnsCnt <= 0)
            {   // set font color of count text as red then run overGame method from gameDirector
                ansCntText.color = Color.red;
                gameDirector.overGame();
                return;
            }
            // ���딻�胊�X�g�̃��Z�b�g
            isCorrectAnswer.Clear();
            QAndA.DOFade(0.0f, 0.1f);
            gameDirector.hasWrongAnswer();
        }
        else
        {
            // �S�␳��
            gameDirector.clearGame();
            answerSystem.SetActive(false);
        }
    }
}
