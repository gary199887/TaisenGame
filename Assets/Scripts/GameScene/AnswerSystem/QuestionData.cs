using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int qNum;                 // 問題番号
    [SerializeField] string qSentence;         // 問題文
    [SerializeField] string[] selectAnswer;    // 解答選択肢
    [SerializeField] string correctAnswer;     // 正解


    public int QNum { get { return qNum; } }
    public string QSentence { get { return qSentence; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
