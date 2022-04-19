using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MapManager : MonoBehaviour
{

    public NodeManager[] nodeList;
    public MapCol[] ColList;
    public NodeManager playerLocation;
    public string battleScene;
    public string shopScene;
    public string repairScene;

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
         foreach (NodeManager node in nodeList)
         {
             if (node.tag.Equals("Start Node"))
             {
                 playerLocation = node;
                 node.enabled = false;
                 //Debug.Log("Start Node Found");
                 break;
             }
         }

         for (int i = 1; i < ColList.Length; i++)
         {
             ColList[i].PreviewCol();
         }
    }

    public void UpdateList(NodeManager node)
    {
        nodeList = GetComponentsInChildren<NodeManager>();
        //Debug.Log("Node List Updated");
        playerLocation = node;
    }

    public void MoveCols(int index)
    {
        if(index + 1 < ColList.Length)
        {
            ColList[index].DisableCol();
            ColList[index + 1].EnableCol();
        }
        else
        {
            Debug.Log("Boss Node Reached");
        }
    }

    public int GetColIndex(MapCol col)
    {
        for(int i = 0; i < ColList.Length; i++)
        {
            if(ColList[i].tag == col.tag)
            {
                return i;
            }
        }
        return 0;
    }

    public void ChangeScene(string sceneToLoad)
    {
        if (sceneToLoad.Equals("Battle"))
        {
            SceneManager.LoadScene(battleScene);
            Debug.Log("Battle Scene Loaded");
        }

        if (sceneToLoad.Equals("Shop"))
        {
            SceneManager.LoadScene(shopScene);
            Debug.Log("Shop Scene Loaded");
        }

        if (sceneToLoad.Equals("Shipyard"))
        {
            SceneManager.LoadScene(repairScene);
            Debug.Log("Shipyard Scene Loaded");
        }
    }

    
}
