using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
    public Vector3 pos;

    public Item(int id, string name, string description, Vector3 pos) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.pos = pos;
    }
}

[Serializable]
public class ItemList {
    public List<Item> items = new List<Item>();

    public void sortItemList() {
        items.Sort((a, b) => { return a.id - b.id; });
    }
}