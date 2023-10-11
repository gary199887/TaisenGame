using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField] AudioSource[] SE;

    public void playClickSE() {
        SE[0].Play();
    }

    public void playItemGetSE() {
        SE[1].Play();
    }

    public void playSelectionChangedSE() {
        SE[2].Play();
    }

    public void playCancelSE()
    {
        SE[3].Play();
    }
}
