using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine.UI; 


public class BattleUI : MonoBehaviour
{
    public Text nameText; 
    public Text hpText; 
    public Slider hpSlider; 

    public void SetupUI(BaseMonster mon){
        nameText.text = mon.monsterName; 
        hpText.text = mon.currHP.ToString(); 
        hpSlider.maxValue = mon.maxHP; 
        hpSlider.value = mon.currHP; 
    }
    public void UpdateHPSlider(int hp){
        hpSlider.value = hp; 
    }
}
