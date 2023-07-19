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

    public bool addAndSortRecord(Record record) {
        records.Add(record);
        records.Sort((a, b) => { if (a.time > b.time) return 1; else return -1; });
        if(records.Count > 5)records.RemoveAt(records.Count - 1);    // remove the last one
        return contains(record);
    }

    public bool contains(Record record) {
        return records.Contains(record);
    }
    
}