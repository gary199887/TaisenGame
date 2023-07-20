using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] int qNum;                 // –â‘è”Ô†
    [SerializeField] string qSentence;         // –â‘è•¶
    [SerializeField] string[] selectAnswer;    // ‰ğ“š‘I‘ğˆ
    [SerializeField] string correctAnswer;     // ³‰ğ


    public int QNum { get { return qNum; } }
    public string QSentence { get { return qSentence; } }
    public string[] SelectAnswer { get { return selectAnswer; } }
    public string CorrectAnswer { get { return correctAnswer; } }
}
