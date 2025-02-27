using UnityEngine; 
using System.Collections; 

public class BattleScript{
    public string AttackerName; 
    public GameObject Attacker;
    public GameObject Target; 
    public void StartBattle(){
        MonsterBehaviour attackerBehavior = Attacker.GetComponent<MonsterBehaviour>(); 
        MonsterBehaviour targetBehavior = Target.GetComponent<MonsterBehaviour>(); 

        if (attackerBehavior != null){
            attackerBehavior.attackTarget= Target.transform; 
            attackerBehavior.current = MonsterBehaviour.State.attacking; 
            
        }
    }

}