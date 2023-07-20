using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] StageQuestionData[] stage;     // ステージ問題データ
    [SerializeField] Text[] questionText;           // 問題文テキスト
    [SerializeField] Text[] selectAnswerText;       // 選択肢テキスト
    [SerializeField] UnityEngine.UI.Button button;  // 初期選択ボタン
    [SerializeField] Text ansCntText;               // 解答可能回数テキスト
    [SerializeField] GameDirector gameDirector;

    const int maxAnsCnt = 3;                        // 最大解答可能回数
    private int currentAnsCnt;                      // 現在の解答可能回数

    List<bool> isCorrectAnswer = new List<bool>();  // 解答正誤判定リスト
    private int currentQNum;                        // 現在の問題番号

    private int stageNum = 0;                       // ステージ番号
    

    private void Start()
    {
        answerSystem.SetActive(false);
        button.Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
        //stageNum = GameDirector.stage - 1;    // ステージ番号を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (!answerSystem.activeSelf) return;     

        if (Input.GetButtonDown("Submit"))
        {
            //button.onClick.Invoke();　   // ボタンを押したことにする
        }
    }

    // 解答開始
    public void StartAnswer()
    {
        PlayerController.canMove = false;   // make player connot do any action

        // 解答可能数をテキストに設定
        ansCntText.text = "解答可能回数：" + currentAnsCnt + "/" + maxAnsCnt;

        // 問題・解答文を設定
        currentQNum = 0;
        SetQAText(currentQNum);
        
        answerSystem.SetActive(true);
    }

    // 解答選択
    public void ClickAnswer(int selectNum)
    {
        // 正誤判定（ステージ対応）
        if (stage[stageNum].Questions[currentQNum].CorrectAnswer ==
            stage[stageNum].Questions[currentQNum].SelectAnswer[selectNum])
        {
            isCorrectAnswer.Add(true);
            Debug.Log("正解");
        }
        else
        {
            isCorrectAnswer.Add(false);
            Debug.Log("不正解");
        }

        ++currentQNum;
        // 全問解答したかチェック
        if (currentQNum == stage[stageNum].Questions.Length)
        {
            // 解答終了
            EndAnswer();
        }
        else
        {
            // 次の問題へ
            SetQAText(currentQNum);
        }
    }

    // 問題・解答文を設定
    private void SetQAText(int currentQNum)
    {
        // （ステージ対応）
        // 問題文をテキストに設定
        questionText[0].text = "Q." + stage[stageNum].Questions[currentQNum].QNum;
        questionText[1].text = stage[stageNum].Questions[currentQNum].QSentence;

        // 回答文をテキストに設定
        selectAnswerText[0].text = stage[stageNum].Questions[currentQNum].SelectAnswer[0];
        selectAnswerText[1].text = stage[stageNum].Questions[currentQNum].SelectAnswer[1];
    }
    
    // 解答終了
    private void EndAnswer()
    {
        
        // 不正解が含まれているかチェック
        if (isCorrectAnswer.Contains(false))
        {
            Debug.Log("不正解あり");
            // 解答権数を減らす
            currentAnsCnt--;
            // 解答権数をテキストに設定
            ansCntText.text = "解答可能回数：" + currentAnsCnt + "/" + maxAnsCnt;
            if (currentAnsCnt <= 0)
            {
                Debug.Log("ゲームオーバー");
                return;
            }
            // 正誤判定リストのリセット
            isCorrectAnswer.Clear();

        }
        else
        {
            // 全問正解
            Debug.Log("全問正解");
            gameDirector.clearGame();
            answerSystem.SetActive(false);
        }
    }
}
