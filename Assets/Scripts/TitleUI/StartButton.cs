using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartButton : MonoBehaviour, Button
{
    [SerializeField]
    ButtonEvent buttonEvent;
    public void onClicked()
    {
        Debug.Log("clicked");
        buttonEvent.GoMenu();
    }
}
