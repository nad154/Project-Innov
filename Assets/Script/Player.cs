using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngineInternal;

public class Player : MonoBehaviour
{
    public string _username {get; private set;}
    public int _AP{get; private set;}
    public List<BaseMonster> MonsterList{get; private set;} = new List<BaseMonster>(); 
    public BaseMonster PlayerMonster{get; set;}
    public bool costActionPoints(int cost){
        if(_AP >= cost){
            _AP -= cost; 
            return true; 
        }
        else{
            return false; 
        }
    }
    public Player(string username, int ap){
        _username = username; 
        _AP = ap; 
    }
    public  void addMonster(BaseMonster monster){
        MonsterList.Add(monster); 
    }
    public void changeMonster(){
        PlayerMonster = MonsterList.ElementAt(MonsterList.IndexOf(PlayerMonster)+1); 
    }



    
}
