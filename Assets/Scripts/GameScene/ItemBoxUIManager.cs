using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxUIManager : MonoBehaviour
{
    [SerializeField]public GameObject itemBoxUI;
    [SerializeField]public GameObject itemPrefab;
    [SerializeField]public GameObject nullHint;
    [SerializeField] public Text itemName;
    [SerializeField] public Text itemDetail;
    [SerializeField] public Canvas canvas;
    List<GameObject> itemGameObjects;
    List<Item> itemObjects;
    int currentShowing;
    float timeCount;                        // timeCounter
    const float cd = 0.2f;                  // gap between two actions(prevent making multiple actions by the same key-down)
    Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
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
        if (itemBoxUI.activeSelf)
        {
            // can do some actions only if talk system is active
            timeCount += Time.deltaTime;
            if (timeCount > cd)  // to make a gap between choice changed or other actions
            {
               
                if (Input.GetAxis("Vertical") < -0.1 && itemGameObjects.Count != 0)  // get next chara
                {
                    itemGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showItem(currentShowing == itemGameObjects.Count - 1 ? currentShowing = 0 : ++currentShowing);
                    //SE[1].Play();
                    timeCount = 0;  // clear counter when whatever actions had been taken
                }
                else if (Input.GetAxis("Vertical") > 0.1 && itemGameObjects.Count != 0)
                {
                    itemGameObjects[currentShowing].GetComponent<Text>().color = Color.white;
                    showItem(currentShowing == 0 ? currentShowing = itemGameObjects.Count - 1 : --currentShowing);
                    //SE[1].Play();
                    timeCount = 0;
                }
                else if (Input.GetButtonDown("Cancel")) {
                    closeItemBox();
                }
            }
        }
    }

    public void showItemBox() {
        PlayerController.canMove = false;
        itemBoxUI.SetActive(true);
        int count = 0;
        foreach (var item in PlayerController.itemBox)
        {
            if (item != null)
            {
                GameObject currentItem = Instantiate(itemPrefab, firstPosition + new Vector3(0.0f, -count * 50f, 0.0f), Quaternion.identity);
                currentItem.GetComponent<Text>().text = item.name;
                currentItem.transform.SetParent(canvas.transform, false);
                itemGameObjects.Add(currentItem);
                itemObjects.Add(item);
                count++;
            }
        }
        if (count == 0) nullHint.SetActive(true);
        else { 
            currentShowing = 0;
            showItem(currentShowing);
        }
    }

    void showItem(int id) {
        itemGameObjects[id].GetComponent<Text>().color = Color.green;
        Item item = itemObjects[id];
        itemName.text = item.name;
        itemDetail.text = item.description;
    }

    void closeItemBox() {
        timeCount = 0;
        foreach (var itemGameObj in itemGameObjects) {
            Destroy(itemGameObj);
        }
        itemGameObjects.Clear();
        itemObjects.Clear();
        itemName.text = "";
        itemDetail.text = "";
        nullHint.SetActive(false);
        itemBoxUI.SetActive(false);
        PlayerController.canMove = true;
    }
}
