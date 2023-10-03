using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;

[Serializable]
public class Talk
{
    public List<Talks> normalTalk;   // [i][j] i-> times
    public string[] alibi;
    public List<Talks> itemTalk; // null -> "•·‚¯‚é‚±‚Æ‚ª‚È‚³‚»‚¤"
    public QA qa;

    public Talk() {
        this.itemTalk = new List<Talks>();
        this.normalTalk = new List<Talks>();
        this.qa = new QA();
    }
}

[Serializable]
public class QA {   // extra Question (q4)
    public string question;
    public string[] answer;
    public Trigger trigger;
}

[Serializable]
public class Trigger {
    public int charaId;
    public int normalTimes;

    public Trigger(int charaId, int normalTimes)
    {
        this.charaId = charaId;
        this.normalTimes = normalTimes;
    }
}


[Serializable]
public class Talks {
    public string[] talks;

    public Talks(string[] input) {
        talks = input;
    }
}