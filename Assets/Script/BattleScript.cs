using UnityEngine; 
using System.Collections;
using UnityEngine.UIElements;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState {
    START, PLAYER1TURN, PLAYER2TURN, WON, LOST 
}

public class BattleScript : MonoBehaviour {
    public GameState state; 
    public GameObject player1; 
    public GameObject player2; 
    public Transform player1Position; 
    public Transform player2Position; 
    BaseMonster UnitPlayer1; 
    BaseMonster UnitPlayer2; 
    public BattleUI player1UI; 
    public BattleUI player2UI; 
    public Text PlayerTurn; 
    public int ActionPointP1; 
    public int ActionPointP2; 

    void Start(){
        state = GameState.START; 
        StartCoroutine(SetupBattle()); 
    }
    IEnumerator SetupBattle(){
        GameObject Player1Obj = Instantiate(player1, player1Position);; 
        GameObject Player2Obj = Instantiate(player2, player2Position); 
        UnitPlayer1 = Player1Obj.GetComponent<BaseMonster>(); 
        UnitPlayer2 = Player2Obj.GetComponent<BaseMonster>(); 
        player1UI.SetupUI(UnitPlayer1); 
        player2UI.SetupUI(UnitPlayer2); 
        yield return new WaitForSeconds(2f); 
        state = GameState.PLAYER1TURN;
        player1Turn(); 
        
    }
    public void player1Turn(){
        PlayerTurn.text = "Player 1"; 
    }
    public void player2Turn(){
        PlayerTurn.text = "Player 2"; 
    }
    public void AttackBtn(){
        if(state != GameState.PLAYER1TURN){
            return; 
        }
        StartCoroutine(PlayerAttack()); 

    }
    IEnumerator PlayerAttack(){
        bool isEnemyDead = UnitPlayer2.
    }



}