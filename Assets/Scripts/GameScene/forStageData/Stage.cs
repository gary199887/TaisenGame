using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stage
{
    public Corpse corpse;
    public List<Chara> charaList;
    public ItemList itemList;
    public Rank rank;
    public List<string> endTalks;

    public Stage() {
        corpse = new Corpse();
        charaList = new List<Chara>();
        itemList = new ItemList();
        rank = new Rank();
        endTalks = new List<string> ();
    }
}
