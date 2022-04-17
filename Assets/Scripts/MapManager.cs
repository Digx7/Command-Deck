using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public NodeManager[] nodeList;
    public MapCol[] ColList;
    public NodeManager playerLocation;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<NodeManager>();
        ColList = GetComponentsInChildren<MapCol>();
        //Debug.Log("Node List Generated");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Player is at " + playerLocation);
        }
    }

    private void Start()
    {
        foreach(NodeManager node in nodeList)
        {
            if(node.tag == "Start Node")
            {
                playerLocation = node;
                node.enabled = false;
                //Debug.Log("Start Node Found");
                break;
            }
        }
    }

    public void UpdateList(NodeManager node)
    {
        nodeList = GetComponentsInChildren<NodeManager>();
        Debug.Log("Node List Updated");
        playerLocation = node;
    }


}
