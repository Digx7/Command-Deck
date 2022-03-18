using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNextNode : MonoBehaviour
{
    public ContactFilter2D filter;
    public Collider2D thisNode;
    RaycastHit2D[] hits;
    AngledRaycast ar;
    public float buffer;
    bool active;

    private void Awake()
    {
        ar = GetComponent<AngledRaycast>();
        hits = new RaycastHit2D[10];
        buffer = 10f;
        active = false;
        thisNode = GetComponent<CircleCollider2D>();
    }

    public void ScanFront()
    {

    }

    public void SetActive()
    {
        active = true;
    }

}
