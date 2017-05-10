using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//saveHighscore when a level was won
public class SaveHighscore : MonoBehaviour {

  private float currentTime;
  private float oldTime;
  private float maxDefaultTime = 3600f; //1 hour in seconds

  private byte saveCounter = 0; //to make sure the score is only saved once

  void Start()
  {
    saveCounter = 0;
  }

	void Update () {
    SaveScore();
  }

  void SaveScore() {
    if (PlayerController.DidWeWin && saveCounter == 0) //when we have won + make sure it only saves once
    {
      currentTime = Timer.TotalTime; //get the totaltime from the timerscript

      if (!PlayerPrefs.HasKey("level " + SceneManager.GetActiveScene().name)) //when it hasn't made a registery for this scene yet
      {
        oldTime = maxDefaultTime; //just fill it with 1 hour in seconds (default)
      }
      else
      {
        oldTime = PlayerPrefs.GetFloat("level " + SceneManager.GetActiveScene().name); //load the highscore for this scene
      }

      if (currentTime < oldTime) //if currentscore faster than old
      {
        oldTime = currentTime;
      }
      PlayerPrefs.SetFloat("level " + SceneManager.GetActiveScene().name, oldTime); //set  highscore in registry (even when not changed/default)
      PlayerPrefs.Save(); //make sure the currentscore is saved
      saveCounter++;
    }
  }
}
