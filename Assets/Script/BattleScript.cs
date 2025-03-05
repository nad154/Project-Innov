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
    public GameObject playerprefab;
    public Transform player1Position; 
    public Transform player2Position; 
    Player UnitPlayer1; 
    Player UnitPlayer2; 
    public GameObject monsterPrefab; 
    public BattleUI player1UI; 
    public BattleUI player2UI; 
    public TMPro.TextMeshProUGUI PlayerTurn; 


    void Start(){
        state = GameState.START; 
        StartCoroutine(SetupBattle()); 
    }
    IEnumerator SetupBattle(){
        GameObject Player1Obj = Instantiate(playerprefab, player1Position);
        GameObject Player2Obj = Instantiate(playerprefab, player2Position); 
        UnitPlayer1 = Player1Obj.GetComponent<Player>(); 
        UnitPlayer2 = Player2Obj.GetComponent<Player>();
        GameObject monster1Obj = Instantiate(monsterPrefab, player1Position.position, Quaternion.identity);
        GameObject monster2Obj = Instantiate(monsterPrefab, player2Position.position, Quaternion.identity);  

        // how to set GameOBJ player to class Player  
        yield return new WaitForSeconds(2f); 
        BaseMonster monster1 = monster1Obj.AddComponent<MonsterID1>();
        BaseMonster monster2 = monster2Obj.AddComponent<MonsterID1>();

        UnitPlayer1.addMonster(monster1);
        UnitPlayer2.addMonster(monster2);
        player1UI.SetupUI(monster1, UnitPlayer1); 
        player2UI.SetupUI(monster2, UnitPlayer2); 

        UnitPlayer1.PlayerMonster = monster1;
        UnitPlayer2.PlayerMonster = monster2;
        state = GameState.PLAYER1TURN;
        // player1Turn(); 
        yield return null; 
        
    }
    // public void player1Turn(){
    //     PlayerTurn.text = "Player 1"; 
    // }
    // public void player2Turn(){
    //     PlayerTurn.text = "Player 2"; 
    // }
    public void AttackBtn1(){
        if(state != GameState.PLAYER1TURN){
            return; 
        }
        // StartCoroutine(PlayerAttack(UnitPlayer1, UnitPlayer2, chosenMove)); 

    }
    // IEnumerator PlayerAttack(Player attacker, Player opponent, MoveSet chosenAttack){
    //     if(state != GameState.PLAYER1TURN && state != GameState.PLAYER2TURN){
    //         yield break; 
    //     }
    //     BaseMonster attackerMonster = attacker.PlayerMonster; 
    //     BaseMonster opponentMonster = opponent.PlayerMonster; 
    //     bool isEnemyDead = chosenAttack.Execute(attacker, opponent, attackerMonster, opponentMonster); 
    //     yield return new WaitForSeconds(3f); 
    //     if (isEnemyDead){
    //         state = GameState.WON; 
    //     }
    //     else{
    //         state = GameState.PLAYER2TURN; 
    //     }

    // }
    public void ExecuteMove(MoveSet chosenMove){
        if(state == GameState.PLAYER1TURN){
            StartCoroutine(PlayerUseMove(UnitPlayer1, UnitPlayer2, chosenMove)); 
        }
        else if (state == GameState.PLAYER2TURN){
            StartCoroutine(PlayerUseMove(UnitPlayer2, UnitPlayer1, chosenMove)); 

        }
    }
    IEnumerator PlayerUseMove(Player user, Player opponent, MoveSet chosenMove)
    {
        if (state != GameState.PLAYER1TURN && state != GameState.PLAYER2TURN){
            yield break;
        }

        BaseMonster attacker = user.PlayerMonster;
        BaseMonster target = opponent.PlayerMonster;

        bool isTargetDefeated = chosenMove.Execute(user, opponent, attacker, target);

        player1UI.UpdateHPSlider(UnitPlayer1.PlayerMonster._currHP);
        player2UI.UpdateHPSlider(UnitPlayer2.PlayerMonster._currHP);

        yield return new WaitForSeconds(1f);

        if (isTargetDefeated)
        {
            if (state == GameState.PLAYER1TURN){
                state = GameState.WON; 
            }
            else{
                state = GameState.LOST; 
            }
            EndBattle();
        }
        else
        {
            if(state == GameState.PLAYER1TURN){
                state = GameState.PLAYER2TURN; 
            }
            else{
                state = GameState.PLAYER1TURN; 
            }
            UpdateTurnUI();
        }

    }

    public void EndBattle(){
        foreach(UnityEngine.UI.Button btn in player1UI.moveBtn) {
            btn.interactable = false; 
        }
        foreach(UnityEngine.UI.Button btn in player2UI.moveBtn){
            btn.interactable = false; 
        }
        if (state == GameState.WON){
            PlayerTurn.text = "Player 1 Wins"; 
        }
        else if (state == GameState.LOST){
            PlayerTurn.text = "Player 2 Wins"; 
        }
        // return to somewhere 
    }
    public void UpdateTurnUI(){
        if (state == GameState.PLAYER1TURN){
            PlayerTurn.text = "Player 1 Turn"; 
            SetMoveBtn(player1UI, true); 
            SetMoveBtn(player2UI, false); 
        }
        else if (state == GameState.PLAYER2TURN){
            PlayerTurn.text= "Player 2 Turn"; 
            SetMoveBtn(player1UI, false); 
            SetMoveBtn(player2UI, true); 
        }
    }
    void SetMoveBtn(BattleUI ui, bool set){
        foreach(UnityEngine.UI.Button btn in ui.moveBtn){
            btn.interactable = set; 
        }
    }
    
}