using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour, Button
{
    public ItemBoxUIManager itemBoxUIManager;
    public void onClicked() {
        itemBoxUIManager.showItemBox();
    }
}
