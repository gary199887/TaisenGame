using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour, Button
{
    [SerializeField] AnswerSystemManager ASManager;
    public void onClicked() {
        //Start Answer System Here, stop player's movement at the same time
        //PlayerController.canMove = false;
        ASManager.StartAnswer();
    }
}
