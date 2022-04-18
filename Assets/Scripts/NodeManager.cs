using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    SpriteRenderer sr;
    MapManager map;
    MapCol column;
    //FindNextNode nodeFinder;
    //public PlayerTracker tracker;
    public Color neutral;
    public string nodeType;
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
        hover = Color.yellow;
        locked = Color.gray;
    }
    private void Update()
    {
        if (!explored && !hovering)
        {
            sr.color = neutral;
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

        //Debug.Log("Travelling to node " + this.name);
        //playerOnNode = true;
        explored = true;
        sr.color = locked;
        map.UpdateList(this);
        //tracker.SetPlayerLocation(this);
    }
}
