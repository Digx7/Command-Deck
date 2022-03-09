using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feild : MonoBehaviour
{
    public List<CardScriptableObject> cards;

    public CardDisplayer cardDisplayer;


    private Stack<Property> propertiesTriggering;

    [SerializeField]
    private Player caster, opponent;

    public void Awake(){
      propertiesTriggering = new Stack<Property>();
      caster = this.gameObject.GetComponentInParent<Player>();
      opponent = findOpponent();
    }

    private Player findOpponent(){
      Player[] players = GameObject.FindObjectsOfType<Player>();
      for(int i = 0; i<players.Length; i++){
        if(players[i].name != "StoreRight" && players[i].name != "StoreLeft" && players[i].GetComponent<Player>() != caster) return players[i].GetComponent<Player>();
      }
      return null;
    }

    public void addCardToFeild(CardScriptableObject card){

      checkCardForTriggerType(card, TriggerType.ETB);

      cards.Add(card);
      cardDisplayer.addCardToBeDisplayed(card);

      proccessStack();
    }

    public void checkAllCardsForTriggerType(TriggerType type){

      if(cards.Count > 0){
        for(int i = 0; i < cards.Count; ++i)
        {
          Debug.Log("There is a perminant on the field");
          checkCardForTriggerType(cards[i], type);
        }
      }
    }

    public void checkCardForTriggerType(CardScriptableObject card, TriggerType type){

      if(card != null && card.triggers.Length > 0){
        for(int i = 0; i < card.triggers.Length; i++){
          if(card.triggers[i].type == type){
            addPropertyToStack(card.triggers[i].property);
          }
        }
      }

    }

    private void addPropertyToStack(Property prop){
      prop.caster = caster;
      prop.opponent = opponent;
      propertiesTriggering.Push(prop);
    }

    public void proccessStack(){
      while(propertiesTriggering.Count != 0){
        Property prop = propertiesTriggering.Pop();
        prop.triggerProperty();
        Debug.Log("A property was triggered");
      }
    }

    public CardScriptableObject removeCardFromFeild(int index){
      CardScriptableObject card = cards[index];

      cards.RemoveAt(index);
      cardDisplayer.removeCardFromBeingDisplayed(index);

      return card;
    }

    public void removeAllCardsFromFeild(){

      cards.Clear();
      cardDisplayer.removeALLCardsFromBeingDisplayed();
    }
}
