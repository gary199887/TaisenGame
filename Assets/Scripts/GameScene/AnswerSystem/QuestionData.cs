using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int qNum;                 // ���ԍ�
    [SerializeField] string qSentence;         // ��蕶
    [SerializeField] string[] selectAnswer;    // �𓚑I����
    [SerializeField] string correctAnswer;     // ����


    public int QNum { get { return qNum; } }
    public string QSentence { get { return qSentence; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
