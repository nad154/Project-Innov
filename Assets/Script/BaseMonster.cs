using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

[System.Serializable]
public class BaseMonster 
{
    public string monsterName; 
    public int maxHP; 
    public int currHP; 
    public void Passive(){

    }

    public void doDamage(){
        
    }

}

[System.Serializable]
public enum MonsterElement{ 
    Water, 
    Grass,
    Fire 
};


