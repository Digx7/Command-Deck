using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSheild", menuName = "ScriptableObjects/Properties/Sheild", order = 1)]
public class Sheild_Property : Property
{
  public int shield_amount;

  public override void triggerProperty(){
    //Rais shild by shield_amount
    Debug.Log("The Sheild property went off");
  }
}
