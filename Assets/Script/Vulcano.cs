using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterID1 : BaseMonster
{
    public MonsterID1() : base("Vulcano", 20, MonsterElement.Fire){
        // MoveList = new List<MoveSet>{
        //     // new BasicAttack("Rock Throw", 1f, 2), 
        //     // new ElementalAttack("Vulcano Eruption", 2f, 3, MonsterElement.Fire)

        // };
    }

}
