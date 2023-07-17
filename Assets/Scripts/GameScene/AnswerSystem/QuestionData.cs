using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int questionNum;          // 問題番号
    [SerializeField] string question;          // 問題文
    [SerializeField] string[] selectAnswer;    // 選択肢
    [SerializeField] string correctAnswer;     // 正解


    public int QuestionNum { get { return questionNum; } }
    public string Question { get { return question; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
