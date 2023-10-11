using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharaInfoUIManager : MonoBehaviour
{
    [SerializeField] Text charaDetail;
    [SerializeField] GameObject charaNamePrefab;
    [SerializeField] ItemBoxUIManager itemBoxUIManager;
    [SerializeField] Canvas canvas;          // canvas as parent of item prefab
    [SerializeField] Text title;
    [SerializeField] SEPlayer sePlayer;
    public static Corpse corpse;
    public static bool showingCharaInfo;
    Vector3 firstPosition;
    List<GameObject> charaGameObjects;
    int currentShowing;                             // current showing item index
    float timeCount;                                // timeCounter
    const float cd = 0.2f;                          // gap between two actions(prevent making multiple actions by the same key-down)


    // Start is called before the first frame update
    void Start()
    {
        charaDetail.gameObject.SetActive(false);
        firstPosition = charaNamePrefab.transform.position;
        currentShowing = 0;
        charaGameObjects = new List<GameObject>();
        showingCharaInfo = false;
        int count = 0;
        foreach (var chara in TalkSystemManager.charaList)
        {
            if (chara != null)
            {   // instantiate chara to UI when the slot is not null(is collected)
                GameObject currentChara = Instantiate(charaNamePrefab, firstPosition + new Vector3(0.0f, -count * 50f, 0.0f), Quaternion.identity);
                currentChara.GetComponent<Text>().text = chara.name;
                // set canvas as parent to make ui displayed
                currentChara.transform.SetParent(canvas.transform, false);
                // add chara to gameObject list
                charaGameObjects.Add(currentChara);
                count++;
            }
        }
        // add corpse
        GameObject corpseUI = Instantiate(charaNamePrefab, firstPosition + new Vector3(0.0f, -count * 50f, 0.0f), Quaternion.identity);
        corpseUI.transform.SetParent(canvas.transform, false);
        charaGameObjects.Add(corpseUI);
        corpseUI.GetComponent<Text>().text = corpse.name;

        foreach (GameObject obj in charaGameObjects)
            obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showingCharaInfo)
        {
            // can do some actions only if itemBox UI is active
            timeCount += Time.deltaTime;
            if (timeCount > cd)  // to make a gap between choice changed or other actions
            {

                if (Input.GetAxis("Vertical") < -0.1 && charaGameObjects.Count != 0)  // get next chara
                {
                    charaGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showChara(currentShowing == charaGameObjects.Count - 1 ? currentShowing = 0 : ++currentShowing);
                    sePlayer.playClickSE();
                    timeCount = 0;  // clear counter when whatever actions had been taken
                }
                else if (Input.GetAxis("Vertical") > 0.1 && charaGameObjects.Count != 0)
                {
                    charaGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showChara(currentShowing == 0 ? currentShowing = charaGameObjects.Count - 1 : --currentShowing);
                    sePlayer.playClickSE();
                    timeCount = 0;
                }

                else if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1)
                {
                    closeCharaList();
                    sePlayer.playSelectionChangedSE();
                    itemBoxUIManager.showItemBox();
                }

                else if (Input.GetButtonDown("Cancel"))
                {
                    closeCharaList();
                    sePlayer.playCancelSE();
                    itemBoxUIManager.closeItemBox();
                }
                //else if (Input.GetButton("Submit"))
                //{
                //    if (chObjects.Count > 0)
                //    {
               
                //    }
                //}
            }
        }
    }

    public void showCharaList() {
        foreach (GameObject obj in charaGameObjects)
            obj.SetActive(true);
        charaDetail.gameObject.SetActive(true);
        showChara(currentShowing);
        showingCharaInfo = true;
        title.text = "êlï®èÓïÒ";
    }

    void showChara(int id) {
        charaGameObjects[id].GetComponent<Text>().color = Color.green;
        if (id < charaGameObjects.Count - 1)
        {
            Chara chara = TalkSystemManager.charaList[id];
            charaDetail.text = $"{chara.name}\nê´ï :{chara.gender}\n\nêlä‘ä÷åW:\n{chara.relationShip}\n\nîÈñß:\n{chara.secret}";
        }
        else {
            charaDetail.text = $"{corpse.name}(éÄñS)\nê´ï :{corpse.gender}\n\néÄëÃèÛãµ:\n{corpse.bodyInfo}\n\nå¬êlèÓïÒ:\n{corpse.relationShip}{corpse.secret}";
        }
    }

    void closeCharaList() {
        charaGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
        timeCount = 0;
        currentShowing = 0;
        showingCharaInfo = false;
        foreach(GameObject charaGameObject in charaGameObjects)
            charaGameObject.SetActive(false);
        charaDetail.gameObject.SetActive(false);
    }
}
