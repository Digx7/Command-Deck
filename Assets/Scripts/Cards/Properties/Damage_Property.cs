using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamage", menuName = "ScriptableObjects/Properties/Damage", order = 1)]
public class Damage_Property : Property
{
    public int damage;

    public override void triggerProperty(){
      opponent.UpdateHealth(-1 * damage);
      Debug.Log("The Damage property went off");
      Debug.Log("The opponent is: " + opponent);
    }
}
