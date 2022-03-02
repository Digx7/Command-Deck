using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTrigger", menuName = "ScriptableObjects/Properties/Trigger", order = 1)]
public class Trigger_Property : Property
{
  //public Effect effect to trigger;

  public override void triggerProperty(){
    //Trigger effect
    Debug.Log("The Trigger property went off");
  }
}
