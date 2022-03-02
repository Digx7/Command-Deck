using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRepair", menuName = "ScriptableObjects/Properties/Repair", order = 1)]
public class Repair_Property : Property
{
  public int repair_amount;

  public override void triggerProperty(){
    caster.UpdateHealth(repair_amount);
    Debug.Log("The Repair property went off");
    Debug.Log("The opponent is: " + opponent);
  }
}
