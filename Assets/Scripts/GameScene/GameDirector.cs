using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    static int stage;
    public static float gameTime;
    public static string playerName;
    public static bool gameClear;
    Stage stageData;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;  // kari, would be set when stage selected
        gameClear = false;
        gameTime = 0;
        playerName = "Unknown";
        stageData = StageManager.loadStage(stage);      // load stage data up to current stage
        setItemList(stageData.itemList);
        setCharaList(stageData.charaList);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameClear)
            gameTime += Time.deltaTime;
    }

    public static string getTimeString() {
        return getTimeString(gameTime);
    }

    public static string getTimeString(float time)
    {
        return $"{time / 60: 00}:{time % 60: 00}";
    }

    public void setItemList(ItemList itemList)
    {
        ItemDetailUIManager.itemList = itemList;
        PlayerController.itemBox = new Item[itemList.items.Count];
    }

    public void setCharaList(List<Chara> charaList) {
        TalkSystemManager.charaList = charaList;
    }

    public static void setPlayerName(string input) {
        playerName = input;
    }
}
