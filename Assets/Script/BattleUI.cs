using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
[System.Serializable]
public class BattleUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText; 
    public TMPro.TextMeshProUGUI hpText; 
    public Slider hpSlider; 
    public Button[] moveBtn; 
    public TMPro.TextMeshProUGUI[] moveBtnTxt; 
    private Player  player; 
    public BattleScript battleManager; 

    public void SetupUI(BaseMonster monster, Player user){
        player = user; 
        nameText.text = monster._monsterName; 
        hpText.text = $"{monster._currHP.ToString()}/{monster._maxHP}"; 
        hpSlider.maxValue = monster._maxHP; 
        hpSlider.value = monster._currHP; 
        UpdateMoveButtons(monster); 
    }
    public void UpdateHPSlider(float hp){
        hpSlider.value = hp; 
        hpText.text = $"{hp}/{hpSlider.maxValue}"; 
    }
    public void UpdateMoveButtons(BaseMonster monster){
        // List<MoveSet> moves = monster.MoveList; 
        List<MoveSet> moves = monster.MoveList; 
        for(int i=0; i< moveBtn.Length; i++){
            if(i<moves.Count){
                moveBtn[i].gameObject.SetActive(true); 
                moveBtnTxt[i].text = moves[i].MoveName; 
                moveBtn[i].onClick.RemoveAllListeners(); 
                int moveIndex = i; 
                moveBtn[i].onClick.AddListener(() => OnMoveButtonPress(moves[moveIndex])); 
            }
            else{
                moveBtn[i].gameObject.SetActive(false);
            }
        }
    }
    void OnMoveButtonPress(MoveSet chosenMove){
        FindObjectOfType<BattleScript>().ExecuteMove(chosenMove); 
    }
}
