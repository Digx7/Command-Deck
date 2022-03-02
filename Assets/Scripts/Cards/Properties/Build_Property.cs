using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuild", menuName = "ScriptableObjects/Properties/Build", order = 1)]
public class Build_Property : Property
{
  // public Card command_Card;
  // add effect

  public override void triggerProperty(){
    // Add effect
    // Add card to hand
    Debug.Log("The Build property went off");
    Debug.Log("The opponent is: " + opponent);
  }
}
