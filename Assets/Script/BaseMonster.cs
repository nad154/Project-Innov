using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

[System.Serializable]
public class BaseMonster 
{
    public string _monsterName {get; protected set;}
    public int _maxHP {get; protected set;}
    public int _currHP{get; set;}
    MonsterElement _element{get; set;}
    public int _defense{get; set;}
    public int _defCounter{get; set;}
    public int _buff{get; set;}
    public BaseMonster(string monsterName, int maxHP, MonsterElement element){
        _monsterName = monsterName; 
        _maxHP = maxHP; 
        _currHP = maxHP;   
        _element = element; 
        _defense = 0; 
        _defCounter = 0; 
    }

}

[System.Serializable]
public enum MonsterElement{ 
    Water, 
    Grass,
    Fire 
};


