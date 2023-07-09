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
        //���̃A�C�e�����X�g�@json�t�@�C���Ɉ�U�Z�[�u���邽�߂̂���
        //ItemList testItemList = new ItemList();
        //testItemList.items.Add(new Item(2, "���܂݂�̎�r", "��Q�҂̌������t������r"));
        //testItemList.items.Add(new Item(1, "�i�C�t", "�qA�̎w�䂪�t�����i�C�t"));
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
