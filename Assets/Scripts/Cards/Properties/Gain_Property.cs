using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGain", menuName = "ScriptableObjects/Properties/Gain", order = 1)]
public class Gain_Property : Property
{
  //public Card card_to_add;

  public override void triggerProperty(){
    //Add card to hand
    Debug.Log("The Gain property went off");
  }
}
