using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageManager : MonoBehaviour
{
    static string filePath = "./Json/.stageData.json";
    public static void saveStage(Stage stage)
    {
        string json = JsonUtility.ToJson(stage);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();

    }

    public static Stage loadStage(int stageNum)
    {
        filePath = "./Json/.stageData" + stageNum + ".json";
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            var stage = JsonUtility.FromJson<Stage>(data);
            return stage;
        }
        return null;
    }
}