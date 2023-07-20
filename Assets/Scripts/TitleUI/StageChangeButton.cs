using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChangeButton : MonoBehaviour,Button
{
    [SerializeField]
    int stageNum;

    public void onClicked()
    {
        GameDirector.stage = stageNum;
        SceneManager.LoadScene("GameScene");   
    }
}
