using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNodeList : MonoBehaviour
{

    NodeManager[] nodeList;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<NodeManager>();
        Debug.Log("Node List Generated");
    }

    public void UpdateList()
    {
        nodeList = GetComponentsInChildren<NodeManager>();
        Debug.Log("Node List Updated");
    }
}
