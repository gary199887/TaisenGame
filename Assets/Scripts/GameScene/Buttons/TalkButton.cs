using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TalkButton : MonoBehaviour, Button
{
    public TalkSystemManager manager;
    public void onClicked() {
        manager.startTalk(TalkSystemManager.currentChosen);
    }
}
