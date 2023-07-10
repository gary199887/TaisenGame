using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Chara
{
    public int id;
    public string name;
    public string gender;
    public string relationShip;
    public string secret;
    public string[] talks;

    public Chara(int id, string name, string gender, string relationShip, string secret, string[] talks) {
        this.id = id;
        this.name = name;
        this.gender = gender;
        this.relationShip = relationShip;
        this.secret = secret;
        this.talks = talks;
    }
}
