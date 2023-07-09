using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUIManager : MonoBehaviour
{
    public GameObject itemDetail;
    public Text itemName;
    public Text itemDescription;
    public static ItemList itemList;
    float cd;
    float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        cd = 0.5f;
        itemDetail.SetActive(false);
        //仮のアイテムリスト　jsonファイルに一旦セーブするためのもの
        //ItemList testItemList = new ItemList();
        //testItemList.items.Add(new Item(2, "血まみれの酒瓶", "被害者の血痕が付いた酒瓶"));
        //testItemList.items.Add(new Item(1, "ナイフ", "客Aの指紋が付いたナイフ"));
        //testItemList.sortItemList();
        //ItemManager.saveItemList(testItemList);
        itemList = ItemManager.loadItemList();
        PlayerController.itemBox = new Item[itemList.items.Count];
    }

    private void Update()
    {
        if (itemDetail.activeSelf)
        {
            timeCount += Time.deltaTime;
            if(timeCount > cd)
            if (Input.GetKeyDown(KeyCode.Z))
            {
                itemDetail.SetActive(false);
                PlayerController.canMove = true;
            }
        }
    }
    public void showItemDetail(int id) {
        timeCount = 0;
        Item item = itemList.items[id];
        itemName.text = item.name;
        itemDescription.text = item.description;
        PlayerController.itemBox[id] = item;
        foreach (Item value in PlayerController.itemBox) {
            Debug.Log(value);
        } ;
        itemDetail.SetActive(true);
    }
}
