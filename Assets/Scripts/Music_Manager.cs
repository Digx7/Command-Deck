using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Manager : MonoBehaviour
{
  private static Music_Manager _instance;

  public static Music_Manager Instance { get { return _instance; } }

  [SerializeField] private List<Music_Cue> CueList;
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private Animator animator;

  private AudioClip nextClip;

  private void Awake()
  {
      if (_instance != null && _instance != this)
      {
          Destroy(this.gameObject);
      } else {
          _instance = this;
      }

      DontDestroyOnLoad(this);
      //SceneManager.activeSceneChanged += CheckIfShouldChangeQue;


      setAllCuesPlayToFalse();
      //ChangeCue();
  }

  public void Start(){
    SceneManager.activeSceneChanged += CheckIfShouldChangeQue;

    //Scene current = SceneManager.GetActiveScene();
    ///CheckIfShouldChangeQue(current, null);
  }

  private void CheckIfShouldChangeQue (Scene current, Scene next){
    Debug.Log("CheckIfShouldChangeQue went off");

    for(int i=0; i < CueList.Count; ++i){
      if(next.name == current.name) return;

      if(shouldChangeCurrentCue(CueList[i], next.name) && Get_isPlaying_ForCue(i)) {
        Debug.Log("Current Music cue should keep playing");
        return;
      }
      else if(shouldChangeCurrentCue(CueList[i], next.name)) {
        Debug.Log("New Music cue should play");
        ChangeCue(i);
      }
    }
  }

  public void ChangeCue (){
    audioSource.clip = nextClip;
  }

  public void Play (){
    audioSource.Play();
  }

  private void ChangeCue (int index){
    setAllCuesPlayToFalse();
    Set_isPlaying_ForCue(index);

    nextClip = CueList[index].song;
    animator.SetTrigger("Transition");
  }

  /*private bool shouldKeepCurrentCue (Music_Cue cue, Scene current){
    bool currentSceneFound = false;
    bool nextSceneFound = false;

    for(int i=0; i < cue.scenesToCueIn.Count; ++i){
      if(current.name == cue.scenesToCueIn[i]) currentSceneFound = true;
      if(next.name == cue.scenesToCueIn[i]) currentSceneFound = true;
    }

    Debug.Log("When checking music cue: " + cue.prefabName + " the current scene was: " + currentSceneFound + " and the next scene was: " + nextSceneFound);
    if(currentSceneFound && nextSceneFound) return true;
    else return false;
  }*/

  private bool shouldChangeCurrentCue (Music_Cue cue, string name){
    for(int i=0; i<cue.scenesToCueIn.Count; ++i){
      if(name == cue.scenesToCueIn[i]) return true;
    }
    return false;
  }

  private void setAllCuesPlayToFalse (){
    for(int i=0; i< CueList.Count; ++i){
      CueList[i].isPlaying = false;
    }
  }

  private void Set_isPlaying_ForCue (int index){
    CueList[index].isPlaying = true;
  }

  private bool Get_isPlaying_ForCue (int index){
    return CueList[index].isPlaying;
  }

}
