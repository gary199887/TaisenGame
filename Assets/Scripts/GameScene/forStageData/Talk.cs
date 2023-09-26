using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Talk
{
    public List<Talks> normalTalk;   // [i][j] i-> times
    public string[] alibi;
    public List<Talks> itemTalk; // null -> "•·‚¯‚é‚±‚Æ‚ª‚È‚³‚»‚¤"

    public Talk() {
        this.itemTalk = new List<Talks>();
        this.normalTalk = new List<Talks>();
    }
}

[Serializable]
public class Talks {
    public string[] talks;

    public Talks(string[] input) {
        talks = input;
    }
}