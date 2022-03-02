using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntercept", menuName = "ScriptableObjects/Properties/Intercept", order = 1)]
public class Intercept_Property : Property
{
  public int intercept_amount;

  public override void triggerProperty(){
    //Raise intercept by intercept_amount
    Debug.Log("The Intercept property went off");
  }
}
