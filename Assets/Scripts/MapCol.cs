using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCol : MonoBehaviour
{

    public NodeManager[] nodesInCol;
    MapManager map;
    public int index;

    private void Awake()
    {
        nodesInCol = GetComponentsInChildren<NodeManager>();
        map = GetComponentInParent<MapManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(NodeManager node in nodesInCol)
        {
            int type = Random.Range(0, 9);
            if(type < 6)
            {
                node.neutral = Color.white;
                node.nodeType = "Battle";
            }
            else if(type == 6 || type == 7)
            {
                node.neutral = Color.blue;
                node.nodeType = "Shop";
            }
            else if (type == 8)
            {
                node.neutral = Color.magenta;
                node.nodeType = "Shipyard";
            }
        }
    }

    public void DisableCol()
    {
        foreach (NodeManager node in nodesInCol)
        {
            node.DisableNode();
        }
    }

    public void EnableCol()
    {
        foreach(NodeManager node in nodesInCol)
        {
            node.EnableNode();
        }
    }
}
