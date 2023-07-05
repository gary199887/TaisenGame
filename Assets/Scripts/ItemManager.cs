using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemManager : MonoBehaviour
{
    static string filePath = "./Json/.itemData.json";
    public static void saveItemList(ItemList itemList)
    {
        string json = JsonUtility.ToJson(itemList);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();

    }

    public static ItemList loadItemList()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            var itemList = JsonUtility.FromJson<ItemList>(data);
            return itemList;
        }
        return null;
    }
}
