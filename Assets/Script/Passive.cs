using UnityEngine;
using System;
using System.Collections;
using System.Reflection;


public enum MonsterName {
    VULCANO, CRYBABY
}

[System.Serializable]
public class Passive : BaseMonster {
    public string passiveName; 
    public string passiveInfo; 
    public MonsterName currMonster; 
    public void PassiveLogic(){
        // if (currMonster == monsterName.VULCANO){

        
    }
}