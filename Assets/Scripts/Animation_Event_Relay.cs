using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Animation_Event_Relay : MonoBehaviour
{
  public List<UnityEvent> EventList;

  public void InvokeEvent(int input){
    EventList[input].Invoke();
  }

  public void StupidFunction (){}
}
