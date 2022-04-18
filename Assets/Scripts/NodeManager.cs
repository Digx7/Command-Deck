using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    SpriteRenderer sr;
    LineRenderer lr;
    MapManager map;
    MapCol column;
    //FindNextNode nodeFinder;
    //public PlayerTracker tracker;
    public Color neutral;
    public string nodeType;
    public NodeManager[] connections;
    Color hover;
    Color locked;
    bool explored;
    bool hovering;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        map = GetComponentInParent<MapManager>();
        column = GetComponentInParent<MapCol>();
        //nodeFinder = GetComponent<FindNextNode>();
        //tracker = GetComponent<PlayerTracker>();
        //neutral = Color.white;
        lr = GetComponent<LineRenderer>();
        hover = Color.yellow;
        locked = Color.gray;
    }

    private void Start()
    {
        lr.positionCount = 2; ;
    }
    private void Update()
    {
        if (!explored && !hovering)
        {
            sr.color = neutral;
        }

        if (this.tag == "Start Node")
        {
            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, connections[0].transform.position);
        }
    }

    private void OnMouseEnter()
    {
        if (!explored)
        {
            sr.color = hover;
            hovering = true;
        }
    }

    private void OnMouseExit()
    {
        if (!explored)
        {
            sr.color = neutral;
            hovering = false;
        }
    }

    private void OnMouseDown()
    {
        if (explored)
        {
            Debug.Log("This node has already been explored");
            return;
        }

        column.DisableCol();
        map.UpdateList(this);
        map.MoveCols(column.index);

        //Debug.Log("Travelling to node " + this.name);
        //playerOnNode = true;
        //explored = true;
        //sr.color = locked;
        //map.UpdateList(this);
        //tracker.SetPlayerLocation(this);
    }

    public void DisableNode()
    {
        explored = true;
        sr.color = locked;
    }

    public void EnableNode()
    {
        explored = false;
        sr.color = neutral;
    }
}
