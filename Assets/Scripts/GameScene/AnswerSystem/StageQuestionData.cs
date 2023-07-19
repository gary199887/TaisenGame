using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageQuestionData", menuName = "ScriptableObjects/StageQuestionData")]
public class StageQuestionData : ScriptableObject
{
    [SerializeField] int stageId;　              // ステージ番号
    [SerializeField] QuestionData[] questions;　 // 問題データ

    public int StageId { get { return stageId; } }
    public QuestionData[] Questions { get { return questions; } }
}
