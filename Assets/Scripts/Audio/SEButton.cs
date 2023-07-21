using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEButton : MonoBehaviour,Button
{

    [SerializeField]
    string seName;
    public void onClicked()
    {
        AudioManager.Instance.Play(seName);
    }
}
