using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : CommonFunctions, Button
{
    [SerializeField] AnswerSystemManager ASManager;
    public void onClicked() {
        //Start Answer System Here, stop player's movement at the same time
        //PlayerController.canMove = false;
        StartCoroutine(DelayMethod(0.1f, () => {
            ASManager.StartAnswer();
        }));
        
    }
}
