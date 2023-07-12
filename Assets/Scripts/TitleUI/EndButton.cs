using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour,Button
{
    [SerializeField]
    ButtonEvent buttonEvent;
    public void onClicked()
    {
        buttonEvent.GameEnd();
    }
}
