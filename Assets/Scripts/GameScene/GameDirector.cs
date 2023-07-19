using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static int stage = 1;
    public static float gameTime;
    public static string playerName;
    public static bool gameClear;
    static Stage stageData;
    public DialogManager dialogManager;
    public Sprite[] backGroundImages;
    public GameObject backGround;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameClear = false;
        gameTime = 0;
        playerName = "Unknown";
        stageData = StageManager.loadStage(stage);      // load stage data up to current stage
        setItemList(stageData.itemList);
        setCharaList(stageData.charaList);
        foreach (Item item in stageData.itemList.items)
        {
            GameObject createItem = Instantiate(itemPrefab, item.pos, Quaternion.identity);
            createItem.name = $"Item_{item.id}";
        }
        backGround.GetComponent<SpriteRenderer>().sprite = backGroundImages[stage - 1];  // set background image up to current stage number
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameClear)
            gameTime += Time.deltaTime;
        else
            if(!dialogManager.dialog.activeSelf)
            SceneManager.LoadScene("ResultScene");
    }

    public static string getTimeString() {
        return getTimeString(gameTime);
    }

    public static string getTimeString(float time)
    {
        return $"{time / 60:00}:{time % 60:00}";
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

    public static Rank getRank() {
        return stageData.rank;
    }

    public static void saveRank(Rank rank) {
        stageData.rank = rank;
        StageManager.saveStage(stageData);
    }

    public void clearGame() {// would add some actions when clearing game
        gameClear = true;
        string[] endHint = stageData.endTalks.ToArray();
        dialogManager.showDialog(endHint);
    }
}
