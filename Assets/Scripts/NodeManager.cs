using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    [SerializeField] SpriteRenderer sr;
    [SerializeField] LineRenderer lr;
    [SerializeField] MapManager map;
    [SerializeField] MapCol column;
    //FindNextNode nodeFinder;
    //public PlayerTracker tracker;
    public Color neutral;
    public string nodeType;
    public NodeManager[] connections;
    public Color hover;
    public Color locked;
    [SerializeField] bool explored;
    [SerializeField] bool hovering;
    public bool access;

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

    private void Update()
    {
        if ((!explored && !hovering) || (!access&& !hovering))
        {
            sr.color = neutral;
        }
    }

    private void OnMouseEnter()
    {
        if (!explored && access)
        {
            sr.color = hover;
            hovering = true;
        }
    }

    private void OnMouseExit()
    {
        if (!explored && access)
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

        if (access)
        {
            column.DisableCol();
            map.UpdateList(this);
            map.MoveCols(column.index);
            map.ChangeScene(nodeType);
        }
        

        //Debug.Log("Travelling to node " + this.name);
        //playerOnNode = true;
        //explored = true;
        //sr.color = locked;
        //map.UpdateList(this);
        //tracker.SetPlayerLocation(this);
    }

    public void PreviewNode()
    {
        access = false;
        sr.color = neutral;
    }

    public void DisableNode()
    {
        explored = true;
        sr.color = locked;
    }

    public void EnableNode()
    {
        access = true;
        explored = false;
        sr.color = neutral;
    }
}
