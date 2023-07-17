using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultDirector : CommonFunctions
{
    public Text stageNameUI;
    public Text timeUI;
    public Text nameUI;
    public Text[] rankUI;
    public InputField nameInput;
    public GameObject anyKey;
    public GameObject currentData, rankList;
    public GameObject newRecord, outOfRank;
    Rank rank;
    Record currentRecord;
    bool canJump;
    bool startMove;
    bool isNewRecord;
    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        startMove = false;
        isNewRecord = false;
        stageNameUI.text = $"Stage{GameDirector.stage}";
        timeUI.text = "TIME:  " + GameDirector.getTimeString();
        nameInput.Select();
        rank = GameDirector.getRank();
        anyKey.SetActive(false);
        newRecord.SetActive(false);
        outOfRank.SetActive(false);
        if (rank == null) rank = new Rank();    // if there is no file at the path, create a new empty rank
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("Title");
            }
            tenmetsu(anyKey);

        }
        if (startMove) {

            float speed = 10f;
            if (rankList.transform.position.x > 1000)
            {
                currentData.transform.Translate(-speed, 0, 0);
                rankList.transform.Translate(-speed, 0, 0);
            } else startMove = false;
        }
        if (isNewRecord) tenmetsu(newRecord);

        endGame();
    }

    public void onEndEnteringName() {
        string name = nameInput.text.Length <= 8 ? nameInput.text : nameInput.text.Substring(0, 8);     //name length limitation in 8
        if (!nameInput.text.Equals("")) GameDirector.setPlayerName(name);
        nameUI.text = "NAME:  " + GameDirector.playerName;
        nameInput.gameObject.SetActive(false);
        currentRecord = new Record(GameDirector.playerName, GameDirector.gameTime);      // create new record instance with current data
        if (rank.addAndSortRecord(currentRecord)) {
            newRecord.transform.position = rankUI[rank.records.IndexOf(currentRecord)].gameObject.transform.position - new Vector3(400, 0, 0);
            isNewRecord = true;

        } else outOfRank.SetActive(true);
        GameDirector.saveRank(rank);
        displayRank();                  // print rank data in the rank list on result
        startMove = true;
        StartCoroutine(DelayMethod(1.5f, () => {    // make a gap to wait for rank being displayed
            canJump = true;
        }));
    }

    void displayRank() {
        int rankNum = rank.records.IndexOf(currentRecord);
        if (rankNum < 5)
        {
            for (int i = 0; i <= rankNum; i++)
            {
                rankUI[i].text = string.Format($"{(i + 1):00}. {rank.records[i].toString()}");      // rankNumber .   corresponding record data in string
            }
            if (rank.records.Count - 1 > rankNum)
                for (int i = rankNum + 1; i < (rank.records.Count < 5 ? rank.records.Count : 5); i++)
                {
                    rankUI[i].text = string.Format($"{(i + 1):00}. {rank.records[i].toString()}");
                }
        }

        else {
            for(int i = 0; i < 5; i++){
                rankUI[i].text = string.Format($"{(rankNum - 4 + i + 1) : 00}. {rank.records[rankNum - 4 + i].toString()}");
            }
        }
    }
}
