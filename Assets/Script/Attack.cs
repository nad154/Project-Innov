using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

[System.Serializable]
public class Attack : BaseMonster {
    public string attackName; 
    public enum AtkElement{ 
        Water, 
        Grass,
        Fire, 
        Physical 
    };
    private int damage; 
    private int pointCost; 

}