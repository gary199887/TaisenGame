using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUIManager : MonoBehaviour
{
    // game objects / components
    public GameObject itemDetail;
    public Text itemName;
    public Text itemDescription;
    [SerializeField] AudioSource cancelSE;
    
    public static ItemList itemList;        // item list for current stage, be set by GameDirector(loading stage data from file)
    float cd;                               // gap(time->sec) between two actions
    float timeCount;                        // timer
    // Start is called before the first frame update
    void Start()
    {
        cd = 0.1f;
        itemDetail.SetActive(false);
    }

    private void Update()
    {
        if (itemDetail.activeSelf)
        {
            timeCount += Time.deltaTime;
            if(timeCount > cd)
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel"))
            {
                timeCount = 0;
                itemDetail.SetActive(false);
                cancelSE.Play();
                PlayerController.canMove = true;
            }
        }
    }

    // start item detail UI
    public void showItemDetail(int id) {
        PlayerController.canMove = false;   // stop player's movement
        timeCount = 0;                      // clear timer
        Item item = itemList.items[id];     // get the item data by id
      
        // set the detail data to corresponded gameObj
        itemName.text = item.name;
        itemDescription.text = item.description;

        // set the item to player's itemBox
        PlayerController.itemBox[id] = item;
        //foreach (Item value in PlayerController.itemBox) {    // check if the item is in itemBox(printed as "null" if it is not)
        //    try { Debug.Log(value.name); }
        //    catch { Debug.Log("null"); }
        //} 

        // make item detail UI visible
        itemDetail.SetActive(true);
    }

   
}
