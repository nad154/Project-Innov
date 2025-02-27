using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

[System.Serializable]
public class BaseMonster
{
    public string monsterName; 
    public int maxHP, currentHP; 
    public void Attack() {

    }
    public void Passive(){

    }
}

[System.Serializable]
public enum Element{ 
    Water, 
    Grass,
    Fire 
};

