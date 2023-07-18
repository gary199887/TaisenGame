using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultDirector : CommonFunctions
{
    // current data UI part
    public Text stageNameUI;        // reveal the stage name such as "Stage1", "Stage2"
    public Text timeUI;
    public Text nameUI;
    public InputField nameInput;
   
    public Text[] rankNameUI;       // name of rank 1~5
    public Text[] rankTimeUI;       // play time of rank 1~5

    // hint the key to press
    public GameObject anyKey;
    // to move the whole two parts
    public GameObject currentData, rankList;
    // two different hints to identify if the current record is in rank
    public GameObject newRecord, outOfRank;

    // local datas
    Rank rank;
    Record currentRecord;
    bool canJump;       // whether can jump to Title Scene or not
    bool startMove;     // whether cuurent data and rank list start to move left
    bool isNewRecord;   // whether curren data is a new record
    // Start is called before the first frame update
    void Start()
    {
        // initialize local booleans and several gameobjects as false
        canJump = false;
        startMove = false;
        isNewRecord = false;
        anyKey.SetActive(false);
        newRecord.SetActive(false);
        outOfRank.SetActive(false);

        // display data from game director
        stageNameUI.text = $"Stage{GameDirector.stage}";
        timeUI.text = "TIME:  " + GameDirector.getTimeString();
        rank = GameDirector.getRank();

        // select input field for entering player's name
        nameInput.Select();
        
        if (rank == null) rank = new Rank();    // if there is no file at the path, create a new empty rank
        
        // if current play time is longer than the last one in rank,
        // skip name-input and just wait for rank sliding out
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
        // not allowed to jump to title immediately
        if (canJump)
        {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("Title");
            }
            tenmetsu(anyKey);

        }

        // move current data part and rank list slide left
        if (startMove) {

            float speed = 10f;
            if (rankList.transform.position.x > 1000)
            {
                currentData.transform.Translate(-speed, 0, 0);
                rankList.transform.Translate(-speed, 0, 0);
            } else startMove = false;
        }

        // turn on/off "new record!!" hint if this time is a new record
        if (isNewRecord) tenmetsu(newRecord);

        endGame();
    }

    public void onEndEnteringName() {
        // name length limitation in 10
        string name = nameInput.text.Substring(0, Mathf.Clamp(nameInput.text.Length, 0, 10));
        if (!nameInput.text.Equals("")) GameDirector.setPlayerName(name);
        
        // update current data into entered name / default name from game director
        nameUI.text = "NAME:  " + GameDirector.playerName;
        nameInput.gameObject.SetActive(false);

        currentRecord = new Record(GameDirector.playerName, GameDirector.gameTime);      // create new record instance with current data
        
        // add current record and return a boolean if this time is in range of top 5
        if (rank.addAndSortRecord(currentRecord)) {
            // if it is, move the new record hint to the corresponding position
            newRecord.transform.position = rankNameUI[rank.records.IndexOf(currentRecord)].gameObject.transform.position - new Vector3(350, 0, 0);
            isNewRecord = true;

        } else outOfRank.SetActive(true);
        GameDirector.saveRank(rank);
        
        displayRank();                  // print rank data into corresponding UI

        StartCoroutine(DelayMethod(2.5f, () =>
        {    // start sliding after waiting for 2.5 sec
            startMove = true;
        }));

        
        StartCoroutine(DelayMethod(4.5f, () => {    
            // make title scene possible to be loaded after 4.5 sec
            canJump = true;
        }));
    }

    // print rank data into corresponding UI
    void displayRank() {
        for (int i = 0; i < rank.records.Count; i++) {
            rankNameUI[i].text = rank.records[i].name;
            rankTimeUI[i].text = GameDirector.getTimeString(rank.records[i].time);
        }
    }
}
