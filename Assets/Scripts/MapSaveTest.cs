using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSaveTest : MonoBehaviour
{

    public MapManager map;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            map.SaveMap();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            map.LoadMap();
        }
    }
}
