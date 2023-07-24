using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSystemManager : MonoBehaviour
{
    [SerializeField] GameObject answerSystem;
    [SerializeField] StageQuestionData[] stage;                 // ステージ問題データ
    [SerializeField] Text[] questionText;                       // 問題文テキスト
    [SerializeField] UnityEngine.UI.Button[] selAnsButtons;     // 選択肢ボタン
    [SerializeField] Text ansCntText;                           // 解答可能回数テキスト
    [SerializeField] GameDirector gameDirector;
    [SerializeField] AudioSource clickSE;

    const int maxAnsCnt = 3;                        // 最大解答可能回数
    private int currentAnsCnt;                      // 現在の解答可能回数
    
    List<bool> isCorrectAnswer = new List<bool>();  // 解答正誤判定リスト
    private int currentQNum;                        // 現在の問題番号

    private int stageNum;                           // ステージ番号
    

    private void Start()
    {
        answerSystem.SetActive(false);
        selAnsButtons[0].Select();
        currentQNum = 0;
        currentAnsCnt = maxAnsCnt;
        stageNum = GameDirector.stage - 1;    // ステージ番号を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (!answerSystem.activeSelf) return;     

        if (Input.GetButtonDown("Submit"))
        {
            //button.onClick.Invoke();　   // ボタンを押したことにする
            if (!(GameDirector.gameClear || GameDirector.gamePause || GameDirector.gameOver)) 
            clickSE.Play();
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
        foreach (var button in selAnsButtons) button.interactable = true;   // make buttons able to be selected when starting answering

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
        // 問題文をテキストに設定
        questionText[0].text = "Q." + stage[stageNum].Questions[currentQNum].QNum;
        questionText[1].text = stage[stageNum].Questions[currentQNum].QSentence;

        // 一度選択肢ボタンを全非表示にする
        for (int i = 0; i < selAnsButtons.Length; i++)
        {
            selAnsButtons[i].gameObject.SetActive(false);
        }

        // 選択肢の数を取得
        int selAnsNum = stage[stageNum].Questions[currentQNum].SelectAnswer.Length;
        // 選択肢の数だけボタンを表示、テキストを設定
        for (int i = 0; i < selAnsNum; i++)
        {
            selAnsButtons[i].gameObject.SetActive(true);
            var selectAnswerText = selAnsButtons[i].GetComponentInChildren<Text>();
            selectAnswerText.text = stage[stageNum].Questions[currentQNum].SelectAnswer[i];
        }
        
        // 選択肢ボタンの位置を設定
        SetAnsButtonPos(selAnsNum);

        selAnsButtons[0].Select();
    }

    // 選択肢ボタンの位置設定
    private void SetAnsButtonPos(int selAnsNum)
    {
        // 選択肢の数が3つなら
        if (selAnsNum == 3)
        {
            for (int i = 0; i < selAnsNum; i++)
            {
                selAnsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -200 * i);
            }
        }
        else
        {
            for (int i = 0; i < selAnsNum; i++)
            {
                selAnsButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(400 * ((i % 2) * 2 - 1), -100 - (200 * (i / 2)));
            }
        }
    }

    // 解答終了
    private void EndAnswer()
    {
        foreach (var button in selAnsButtons) button.interactable = false;      // make buttons not able to be selected when ending answering
        // 不正解が含まれているかチェック
        if (isCorrectAnswer.Contains(false))
        {
            Debug.Log("不正解あり");
            // 解答権数を減らす
            currentAnsCnt--;
            // 解答権数をテキストに設定
            ansCntText.text = "解答可能回数：" + currentAnsCnt + "/" + maxAnsCnt;
            if (currentAnsCnt <= 0)
            {   // set font color of count text as red then run overGame method from gameDirector
                ansCntText.color = Color.red;
                gameDirector.overGame();
                Debug.Log("ゲームオーバー");
                return;
            }
            // 正誤判定リストのリセット
            isCorrectAnswer.Clear();
            gameDirector.hasWrongAnswer();
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
