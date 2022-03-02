using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public string name;

    public int currentLife, maxLife;

    //public Enemy_Action[] actions;

    public void UpdatedHealth(int input){
      currentLife += input;
      //healthChanged.Invoke(currentLife);
      //if(currentLife <= 0)playerDied.Invoke();
    }

    public void PlanAction(){
      // The enemy should plan what it will do on the next turn
    }

    public void DoAction(){
      // The enemy should do it's action
    }
}
