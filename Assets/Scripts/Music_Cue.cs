using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cue", menuName = "ScriptableObjects/Music_Cue", order = 1)]
public class Music_Cue : ScriptableObject
{
    public string prefabName;
    public bool isPlaying = false;

    public AudioClip song;
    public string sceneToCueIn;
    public List<string> scenesToCueIn;
}
