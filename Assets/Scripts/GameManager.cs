using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public void Start(){
      startGame();
    }

    public void startGame(){
      //opening animations
      //Indicate enemies first moves
      player.setUpLibrary();

      nextRound();
    }

    public void nextRound(){
      player.Draw();
      player.RefillMana();
    }

    public void endPlayerTurn(){
      //Check game state
      //if no one's dead continue

      player.emptyMana();
      player.DiscardAtTurnEnd();
    }

    public void enemyTurn(){
      //Enemies take actions

      //Check game state
      //if no one's dead continue

      nextRound();
    }

    public void PlayerWon(){
      //Play win animations
    }

    public void PlayerLost(){
      //Play lose animations
    }
}
