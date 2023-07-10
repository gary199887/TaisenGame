using System;
using System.Collections.Generic;

[Serializable]
public class Record
{
    public string name;
    public float time;

    public Record(string name = "UNKNOWN", float time = 0)
    {
        this.name = name;
        this.time = time;
    }

    public string toString() {
        return name.PadRight(8) + "  " + "    "+ GameDirector.getTimeString(time) + "  ";
    }
}
[Serializable]
public class Rank {
    public List<Record> records = new List<Record>();
    
}