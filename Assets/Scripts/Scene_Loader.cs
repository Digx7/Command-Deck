using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    private string nextScene;

    public void LoadNewScene(string sceneName){
      Debug.Log("Loading New Scene");
      SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene (){
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Set_NextScene(string sceneName){
      nextScene = sceneName;
    }

    public void LoadNextScene(){
      LoadNewScene(nextScene);
    }

    public void QuitGame(){
      Application.Quit();
    }
}
