using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour, Button
{
    [SerializeField]
    ButtonEvent buttonEvent;

    public void onClicked()
    {
        buttonEvent.BackTitle();
    }


}
