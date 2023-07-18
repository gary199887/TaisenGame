using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            buttonEvent.ChangeScene(sceneName);
        }
        else
        {
            buttonEvent.ChangeScene(stageNum);
        }

        
    }
}
