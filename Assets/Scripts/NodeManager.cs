using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    SpriteRenderer sr;
    GenerateNodeList listUpdate;
    Color neutral;
    Color hover;
    Color locked;
    bool explored;
    bool playerOnNode;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        listUpdate = GetComponentInParent<GenerateNodeList>();
        neutral = Color.white;
        hover = Color.yellow;
        locked = Color.gray;
    }

    private void OnMouseEnter()
    {
        if (!explored)
        {
            sr.color = hover;
        }
    }

    private void OnMouseExit()
    {
        if (!explored)
        {
            sr.color = neutral;
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
        playerOnNode = true;
        explored = true;
        sr.color = locked;
        listUpdate.UpdateList();
    }
}
