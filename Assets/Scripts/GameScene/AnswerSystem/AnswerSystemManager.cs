using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] QuestionData[] qData;          // 問題データ
    [SerializeField] Text[] questionText;           // 問題文テキスト
    [SerializeField] Text[] selectAnswerText;       // 選択肢テキスト
    [SerializeField] UnityEngine.UI.Button button;
    [SerializeField] Text ansCntText;               // 解答権数テキスト
    const int maxAnsCnt = 3;                        // 最大解答可能回数
    private int currentAnsCnt;                      // 現在の解答可能回数

    List<bool> isCorrectAnswer = new List<bool>();  // 解答正誤判定リスト
    private int currentQNum;                        // 現在の問題番号

    private void Start()
    {
        answerSystem.SetActive(false);
        button.Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
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

        // 解答権数をテキストに設定
        ansCntText.text = "解答可能回数：" + currentAnsCnt + "/" + maxAnsCnt;

        // 問題文をテキストに設定
        currentQNum = 0;
        SetQAText(currentQNum);
        
        answerSystem.SetActive(true);
    }

    // 解答選択
    public void ClickAnswer(int selectNum)
    {
        // 正誤判定
        if (qData[currentQNum].CorrectAnswer == qData[currentQNum].SelectAnswer[selectNum])
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
        if (currentQNum == qData.Length)
        {
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
        // 問題文をテキストに設定
        questionText[0].text = "Q." + qData[currentQNum].QuestionNum;
        questionText[1].text = qData[currentQNum].Question;

        // 回答文をテキストに設定
        selectAnswerText[0].text = qData[currentQNum].SelectAnswer[0];
        selectAnswerText[1].text = qData[currentQNum].SelectAnswer[1];
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
            if(currentAnsCnt <= 0)
            {
                Debug.Log("ゲームオーバー");
                return;
            }
            // 正誤判定リストのリセット
            isCorrectAnswer.Clear();
            // 操作パートへ戻る
            PlayerController.canMove = true;
            answerSystem.SetActive(false);
        }
        else
        {
            // 全問正解
            Debug.Log("全問正解");
            GameDirector gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
            gameDirector.clearGame();
            answerSystem.SetActive(false);
        }
    }
}
