using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
public void  QuitGame() 
  {
    SceneManager.LoadScene("StartScene");
    Debug.Log("Quit");
    //Application.Quit();
  }
 
}
