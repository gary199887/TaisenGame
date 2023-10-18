using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxUIManager : MonoBehaviour
{
    [SerializeField] public GameObject itemBoxUI;
    [SerializeField] public GameObject itemPrefab;
    [SerializeField] public GameObject nullHint;
    [SerializeField] public Text itemName;
    [SerializeField] public Text itemDetail;
    [SerializeField] Text listTitle;
    [SerializeField] public Canvas canvas;          // canvas as parent of item prefab
    [SerializeField] public TalkSystemManager talkSystemManager;
    [SerializeField] CharaInfoUIManager charaInfoUIManager;
    [SerializeField] Text zHint;
    [SerializeField] Text xHint;
    [SerializeField] SEPlayer sePlayer;
    [SerializeField] GameObject playTimeUI;
    List<GameObject> itemGameObjects;               // temporary gameObject list to destroy when itembox be closed
    List<Item> itemObjects;                         // item list attached to gameObject list to get the corresponding item detail
    int currentShowing;                             // current showing item index
    float timeCount;                                // timeCounter
    const float cd = 0.2f;                          // gap between two actions(prevent making multiple actions by the same key-down)
    Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
        // when gamescene loaded
        itemBoxUI.SetActive(false);
        nullHint.SetActive(false);
        itemGameObjects = new List<GameObject>();
        itemObjects = new List<Item>();
        firstPosition = itemPrefab.transform.position;
        itemName.text = "";
        itemDetail.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (itemBoxUI.activeSelf && !CharaInfoUIManager.showingCharaInfo)
        {
            // can do some actions only if itemBox UI is active
            timeCount += Time.deltaTime;
            if (timeCount > cd)  // to make a gap between choice changed or other actions
            {

                if (Input.GetAxis("Vertical") < -0.1 && itemGameObjects.Count != 0)  // get next chara
                {
                    itemGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showItem(currentShowing == itemGameObjects.Count - 1 ? currentShowing = 0 : ++currentShowing);
                    sePlayer.playClickSE();
                    timeCount = 0;  // clear counter when whatever actions had been taken
                }
                else if (Input.GetAxis("Vertical") > 0.1 && itemGameObjects.Count != 0)
                {
                    itemGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showItem(currentShowing == 0 ? currentShowing = itemGameObjects.Count - 1 : --currentShowing);
                    sePlayer.playClickSE();
                    timeCount = 0;
                }

                else if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1) {
                    if (!TalkSystemManager.choosingQuestion)
                    {
                        changeToCharaInfo();
                        charaInfoUIManager.showCharaList();
                    }
                }
                else if (Input.GetButtonDown("Cancel"))
                {
                    if (TalkSystemManager.choosingQuestion)
                        talkSystemManager.startTalk(TalkSystemManager.currentChosen);
                    sePlayer.playCancelSE();
                    closeItemBox();
                }
                else if (Input.GetButton("Submit"))
                {
                    if (itemObjects.Count > 0 && TalkSystemManager.choosingQuestion)
                    {
                        talkSystemManager.showItemTalk(itemObjects[currentShowing].id);
                        closeItemBox();
                    }
                }
            }
        }
    }

    // called by other scripts to open itemBox UI
    public void showItemBox() {
        listTitle.text = "アイテム情報";
        PlayerController.canMove = false;
        itemBoxUI.SetActive(true);
        // not to reveal playTime UI when player is asking about items
        playTimeUI.SetActive(!TalkSystemManager.choosingQuestion);
        int count = 0; // collected item num
        // check items in itemBox
        foreach (var item in PlayerController.itemBox)
        {
            if (item != null)
            {   // instantiate item to UI when the slot is not null(is collected)
                GameObject currentItem = Instantiate(itemPrefab, firstPosition + new Vector3(0.0f, -count * 50f, 0.0f), Quaternion.identity);
                currentItem.GetComponent<Text>().text = item.name;
                // set canvas as parent to make ui displayed
                currentItem.transform.SetParent(canvas.transform, false);
                // add the item to temporary lists
                itemGameObjects.Add(currentItem);
                itemObjects.Add(item);
                count++;
            }
        }
        // hint "item box is null now" if itembox is null
        if (count == 0) nullHint.SetActive(true);
        else { 
            currentShowing = 0;
            showItem(currentShowing);
        }

        // set if the hints be active
        if (TalkSystemManager.choosingQuestion)
        {
            zHint.text = "Z　聞く";
            xHint.text = "X　閉じる";
        }
        else {
            zHint.text = "←→　アイテム/人物情報";
            xHint.text = "   X　閉じる";
        }
    }

    // show item detail with index of temporary index
    void showItem(int id) {
        timeCount = 0;
        itemGameObjects[id].GetComponent<Text>().color = Color.green;
        Item item = itemObjects[id];
        itemName.text = item.name;
        itemDetail.text = item.description;
    }

    // close itemBox UI
    public void closeItemBox() {
        timeCount = 0;

        foreach (var itemGameObj in itemGameObjects) {
            // clear text UI gameObjects
            Destroy(itemGameObj);
        }
        itemGameObjects.Clear();
        itemObjects.Clear();
        itemName.text = "";
        itemDetail.text = "";
        nullHint.SetActive(false);
        itemBoxUI.SetActive(false);
        if(!TalkSystemManager.choosingQuestion)
        PlayerController.canMove = true;
    }

    void changeToCharaInfo() {
        timeCount = 0;
        sePlayer.playSelectionChangedSE();
        foreach (var itemGameObj in itemGameObjects)
        {
            // clear text UI gameObjects
            Destroy(itemGameObj);
        }
        itemGameObjects.Clear();
        itemObjects.Clear();
        itemName.text = "";
        itemDetail.text = "";
        nullHint.SetActive(false);
        
    }
}
