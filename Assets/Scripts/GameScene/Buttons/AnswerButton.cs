using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour, Button
{
    public void onClicked() {
        //Start Answer System Here, stop player's movement at the same time
        //PlayerController.canMove = false;
        Debug.Log("Answer!");
    }
}
