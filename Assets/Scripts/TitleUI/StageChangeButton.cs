using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChangeButton : MonoBehaviour,Button
{
    [SerializeField]
    ButtonEvent buttonEvent;

    enum Mode
    {
        SceneNameChange,
        StageNumberChange
    }

    [SerializeField]
    Mode mode;

    
    [SerializeField]
    string sceneName;

    [SerializeField]
    int stageNum;

    public void onClicked()
    {
        if (mode.Equals(Mode.SceneNameChange))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            GameDirector.stage = stageNum;
            SceneManager.LoadScene("GameScene");
        }

        
    }
}
