using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildInfo : MonoBehaviour
{
    [SerializeField] private string build_Ver;

    public StringEvent buildInfo;

    public void Start (){
      // update build_Ver with correct info

      build_Ver = Application.version;

      buildInfo.Invoke(build_Ver);
    }
}
