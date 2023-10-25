using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeUIUpdater : MonoBehaviour
{
    [SerializeField] Text playTimeText;
    // Update is called once per frame
    void Update()
    {
        playTimeText.text = "ÉvÉåÉCéûä‘ÅF" + GameDirector.getTimeString();
    }
}
