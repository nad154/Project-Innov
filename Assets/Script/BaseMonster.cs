    using UnityEngine;
    using System;
    using System.Collections;
    using System.Reflection;
using System.Collections.Generic;

[System.Serializable]
    [CreateAssetMenu(fileName = "New Monster", menuName = "New Monster")]
    public class BaseMonster : MonoBehaviour    
    {
        public string _monsterName {get; protected set;}
        public float _maxHP {get; protected set;}
        public float _currHP{get; set;}
        public MonsterElement _element{get; set;}
        public float _defense{get; set;}
        public int _defCounter{get; set;}
        public float _buff{get; set;}
        [SerializeField] public MoveSet[] _moveList; 
        public MoveSet[] MoveList=> _moveList; 
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
        Fire, 
        Poison
    };


