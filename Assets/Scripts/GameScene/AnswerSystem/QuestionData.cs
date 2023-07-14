using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int questionNum;          // –â‘è”Ô†
    [SerializeField] string question;          // –â‘è•¶
    [SerializeField] string[] selectAnswer;    // ‘I‘ğˆ
    [SerializeField] string correctAnswer;     // ³‰ğ


    public int QuestionNum { get { return questionNum; } }
    public string Question { get { return question; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
