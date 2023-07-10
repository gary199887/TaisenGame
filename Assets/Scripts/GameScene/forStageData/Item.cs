using System;
using System.Collections.Generic;

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;

    public Item(int id, string name, string description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}

[Serializable]
public class ItemList {
    public List<Item> items = new List<Item>();

    public void sortItemList() {
        items.Sort((a, b) => { return a.id - b.id; });
    }
}