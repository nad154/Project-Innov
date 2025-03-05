using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "New Attack")]
public class BasicAttack : MoveSet 
{
    // [SerializeField] private string _attackName; 
    [SerializeField] private float _damage; 
    // public string AttackName => _attackName; 
    public float Damage => _damage; 
    // public int _APCost{get; protected set;}
    public override bool Execute(Player P1, Player P2, BaseMonster attacker, BaseMonster opponent){
        if(P1.costActionPoints(APCost)){
            opponent._currHP -= (_damage + attacker._buff) - opponent._defense; 
            return CheckDeath(opponent); 
        }
        //insert function for showing that AP is not enough 
        return false; 
        
    }
    // public BasicAttack(string attackName, float damage, int APCost){
    //     _attackName = attackName; 
    //     _damage = damage;
    //     // _APCost = APCost; 
    // }


}
