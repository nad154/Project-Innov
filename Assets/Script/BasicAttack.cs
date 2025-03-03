using UnityEngine;

public class BasicAttack
{
    public string _attackName{get; protected set;}
    public int _damage{get; protected set;} 
    public int _APCost{get; protected set;}
    public virtual bool DoDamage(BaseMonster attacker, BaseMonster opponent){
        opponent._currHP -= (_damage + attacker._buff) - opponent._defense; 
        return CheckDeath(opponent); 
    }
    public BasicAttack(string attackName, int damage, int APCost){
        _attackName = attackName; 
        _damage = damage; 
        _APCost = APCost; 
    }

    public bool CheckDeath(BaseMonster opponent)
    {
        if(opponent._currHP <= 0){
            return true; 
        }
        else {
            return false; 
        }   
    }
}
