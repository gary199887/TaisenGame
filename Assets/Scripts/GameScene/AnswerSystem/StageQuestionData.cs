using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageQuestionData", menuName = "ScriptableObjects/StageQuestionData")]
public class StageQuestionData : ScriptableObject
{
    [SerializeField] int stageId;�@              // �X�e�[�W�ԍ�
    [SerializeField] QuestionData[] questions;�@ // ���f�[�^

    public int StageId { get { return stageId; } }
    public QuestionData[] Questions { get { return questions; } }
}
