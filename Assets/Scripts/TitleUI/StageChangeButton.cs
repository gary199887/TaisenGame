using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChangeButton : MonoBehaviour,Button
{
    [SerializeField]
    ButtonEvent buttonEvent;
    [SerializeField]
    string sceneName;

    public void onClicked()
    {
        buttonEvent.ChangeScene(sceneName);
    }
}
