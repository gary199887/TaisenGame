using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] QuestionData[] qData;          // ���f�[�^
    [SerializeField] Text[] questionText;           // ��蕶�e�L�X�g
    [SerializeField] Text[] selectAnswerText;       // �I�����e�L�X�g
    [SerializeField] UnityEngine.UI.Button button;
    [SerializeField] Text ansCntText;               // �𓚌����e�L�X�g
    const int maxAnsCnt = 3;                        // �ő�𓚉\��
    private int currentAnsCnt;                      // ���݂̉𓚉\��

    List<bool> isCorrectAnswer = new List<bool>();  // �𓚐��딻�胊�X�g
    private int currentQNum;                        // ���݂̖��ԍ�

    private void Start()
    {
        answerSystem.SetActive(false);
        button.Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
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

        // �𓚌������e�L�X�g�ɐݒ�
        ansCntText.text = "�𓚉\�񐔁F" + currentAnsCnt + "/" + maxAnsCnt;

        // ��蕶���e�L�X�g�ɐݒ�
        currentQNum = 0;
        SetQAText(currentQNum);
        
        answerSystem.SetActive(true);
    }

    // �𓚑I��
    public void ClickAnswer(int selectNum)
    {
        // ���딻��
        if (qData[currentQNum].CorrectAnswer == qData[currentQNum].SelectAnswer[selectNum])
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
        if (currentQNum == qData.Length)
        {
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
        questionText[0].text = "Q." + qData[currentQNum].QuestionNum;
        questionText[1].text = qData[currentQNum].Question;

        // �񓚕����e�L�X�g�ɐݒ�
        selectAnswerText[0].text = qData[currentQNum].SelectAnswer[0];
        selectAnswerText[1].text = qData[currentQNum].SelectAnswer[1];
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
