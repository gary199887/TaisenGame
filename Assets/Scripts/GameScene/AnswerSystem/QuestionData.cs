using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int questionNum;          // ���ԍ�
    [SerializeField] string question;          // ��蕶
    [SerializeField] string[] selectAnswer;    // �I����
    [SerializeField] string correctAnswer;     // ����


    public int QuestionNum { get { return questionNum; } }
    public string Question { get { return question; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
