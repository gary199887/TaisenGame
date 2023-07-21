using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageQuestionData", menuName = "ScriptableObjects/StageQuestionData")]
public class StageQuestionData : ScriptableObject
{
    [SerializeField] QuestionData[] questions;　 // 問題データ

    public QuestionData[] Questions { get { return questions; } }
}
