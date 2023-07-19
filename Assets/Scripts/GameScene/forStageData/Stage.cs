using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stage
{
    public List<Chara> charaList;
    public ItemList itemList;
    public Rank rank;
    public List<string> endTalks;

    public Stage() {
        charaList = new List<Chara>();
        itemList = new ItemList();
        rank = new Rank();
        endTalks = new List<string> ();
    }
}
