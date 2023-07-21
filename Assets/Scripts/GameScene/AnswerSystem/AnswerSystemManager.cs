using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] StageQuestionData[] stage;                 // �X�e�[�W���f�[�^
    [SerializeField] Text[] questionText;                       // ��蕶�e�L�X�g
    [SerializeField] UnityEngine.UI.Button[] selAnsButtons;     // �I�����{�^��
    [SerializeField] Text ansCntText;                           // �𓚉\�񐔃e�L�X�g
    const int maxAnsCnt = 3;                        // �ő�𓚉\��
    private int currentAnsCnt;                      // ���݂̉𓚉\��
    
    List<bool> isCorrectAnswer = new List<bool>();  // �𓚐��딻�胊�X�g
    private int currentQNum;                        // ���݂̖��ԍ�

    private int stageNum = 0;                       // �X�e�[�W�ԍ�
    

    private void Start()
    {
        answerSystem.SetActive(false);
        selAnsButtons[0].Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
        //stageNum = GameDirector.stage - 1;    // �X�e�[�W�ԍ����擾
    }

    // Update is called once per frame
    void Update()
    {
        if (!answerSystem.activeSelf) return;     

        if (Input.GetButtonDown("Submit"))
        {
            //button.onClick.Invoke();�@   // �{�^�������������Ƃɂ���
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
            Debug.Log("����");
        }
        else
        {
            isCorrectAnswer.Add(false);
            Debug.Log("�s����");
        }

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
            SetQAText(currentQNum);
        }
    }

    // ���E�𓚕���ݒ�
    private void SetQAText(int currentQNum)
    {
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
            Debug.Log("�s��������");
            // �𓚌��������炷
            currentAnsCnt--;
            if(currentAnsCnt <= 0)
            {
                Debug.Log("�Q�[���I�[�o�[");
                return;
            }
            // ���딻�胊�X�g�̃��Z�b�g
            isCorrectAnswer.Clear();
            // ����p�[�g�֖߂�
            PlayerController.canMove = true;
            answerSystem.SetActive(false);
        }
        else
        {
            // �S�␳��
            Debug.Log("�S�␳��");
            GameDirector gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
            gameDirector.clearGame();
            answerSystem.SetActive(false);
        }
    }
}
