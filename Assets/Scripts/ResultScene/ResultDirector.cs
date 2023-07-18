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
    public Text[] rankNameUI;
    public Text[] rankTimeUI;
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
        if (rank.records.Count >= 5)
        {
            Record lastRecord = rank.records[rank.records.Count - 1];
            if (lastRecord.time < GameDirector.gameTime)
            {
                onEndEnteringName();
            }
        }
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
        string name = nameInput.text.Substring(0, Mathf.Clamp(nameInput.text.Length, 0, 10));     //name length limitation in 8
        if (!nameInput.text.Equals("")) GameDirector.setPlayerName(name);
        
        nameUI.text = "NAME:  " + GameDirector.playerName;
        nameInput.gameObject.SetActive(false);
        currentRecord = new Record(GameDirector.playerName, GameDirector.gameTime);      // create new record instance with current data
        
        
        if (rank.addAndSortRecord(currentRecord)) {
            newRecord.transform.position = rankNameUI[rank.records.IndexOf(currentRecord)].gameObject.transform.position - new Vector3(350, 0, 0);
            isNewRecord = true;

        } else outOfRank.SetActive(true);
        GameDirector.saveRank(rank);
        
        displayRank();                  // print rank data in the rank list on result
        StartCoroutine(DelayMethod(2.5f, () =>
        {    // make a gap to wait for rank being displayed
            startMove = true;
        }));
        StartCoroutine(DelayMethod(4.5f, () => {    // make a gap to wait for rank being displayed
            canJump = true;
        }));
    }

    void displayRank() {
        for (int i = 0; i < rank.records.Count; i++) {
            rankNameUI[i].text = rank.records[i].name;
            rankTimeUI[i].text = GameDirector.getTimeString(rank.records[i].time);
        }
    }
}
