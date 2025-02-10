using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadSceneAsync(1); //change to whatever the scene name or build index that our level 1 is
    }

    public void QuitGame(){
        Application.Quit();
    }
}
