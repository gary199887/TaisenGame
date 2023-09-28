using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageManager : MonoBehaviour
{
    static string filePath = "./Json/.stageData.json";
    public static void saveStage(Stage stage)
    {
        filePath = "./Json/.stageDataTest.json";
        string json = JsonUtility.ToJson(stage);
        Debug.Log(json);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();

    }

    public static Stage loadStage(int stageNum)
    {
        //filePath = "./Json/.stageData" + stageNum + ".json";
        filePath = "./Json/.stageDataTest.json";
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            var stage = JsonUtility.FromJson<Stage>(data);
            return stage;
        }
        return null;
    }
}
