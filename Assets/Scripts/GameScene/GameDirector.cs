using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : CommonFunctions
{
    // current data
    public static int stage = 2;
    public static float gameTime;
    public static string playerName;

    // game status
    public static bool gameClear;
    public static bool gamePause;
    public static bool gameOver;
    
    // stage data
    static Stage stageData;
    
    // game obejcts
    public DialogManager dialogManager;
    [SerializeField] GameObject answerSystem;
    public Sprite[] backGroundImages;
    public GameObject backGround;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // initialize status and data
        gameClear = false;
        gamePause = false;
        gameOver = false;
        gameTime = 0;
        playerName = "Unknown";

        // load stage data up to current stage number
        stageData = StageManager.loadStage(stage);
        setItemList(stageData.itemList);
        setCharaList(stageData.charaList);
        // create items with stage data
        foreach (Item item in stageData.itemList.items)
        {
            GameObject createItem = Instantiate(itemPrefab, item.pos, Quaternion.identity);
            createItem.name = $"Item_{item.id}";
        }

        // set background image depends on current stage number
        backGround.GetComponent<SpriteRenderer>().sprite = backGroundImages[stage - 1]; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameClear)
            gameTime += Time.deltaTime;
        else
            if(!dialogManager.dialog.activeSelf)
            SceneManager.LoadScene("ResultScene");

        // back to detective part if there is a wrong answer
        if (gamePause && !dialogManager.dialog.activeSelf)
        {
            gamePause = false;
            PlayerController.canMove = true;
            answerSystem.SetActive(false);
        }

        // load tilte scene if answer counter in 0
        if(gameOver && !dialogManager.dialog.activeSelf)
                SceneManager.LoadScene("Title");
        endGame();
    }

    // get gameTime string
    public static string getTimeString() {
        return getTimeString(gameTime);
    }
    // turning time(sec) float into string in format "mm:ss"
    public static string getTimeString(float time)
    {
        return $"{time / 60:00}:{time % 60:00}";
    }

    // initialize itemlist after loading data at the beginning of the game
    public void setItemList(ItemList itemList)
    {
        ItemDetailUIManager.itemList = itemList;
        PlayerController.itemBox = new Item[itemList.items.Count];
    }

    // initialize charalist after loading data
    public void setCharaList(List<Chara> charaList) {
        TalkSystemManager.charaList = charaList;
    }

    public static void setPlayerName(string input) {
        playerName = input;
    }

    public static Rank getRank() {
        return stageData.rank;
    }

    // save cuurent record into json file
    public static void saveRank(Rank rank) {
        stageData.rank = rank;
        StageManager.saveStage(stageData);
    }

    // show gameclear hint
    public void clearGame() {
        string[] endHint = stageData.endTalks.ToArray();
        dialogManager.showDialog(endHint);
        gameClear = true;
    }

    // show wrong answer hint
    public void hasWrongAnswer() {
        string[] wrongHint = { "間違いがあるよ" };
        dialogManager.showDialog(wrongHint);
        gamePause = true;
    }

    // show gameover hint
    public void overGame() {
        string[] overHint = {"残念...ゲームオーバーだよ", "Zキーでタイトルへ戻る" };
        dialogManager.showDialog(overHint);
        gameOver = true;
    }
}
