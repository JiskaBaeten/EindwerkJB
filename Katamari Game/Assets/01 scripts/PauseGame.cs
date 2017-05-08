using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pause window + quit option / return to menu options
public class PauseGame : MonoBehaviour
{
  public GameObject pausePanel; //pausepanel to show
  private byte MenuLvlNumber = 0; //to load the menu

  void Start()
  {
    pausePanel.SetActive(false); //make sure it isn't visible at this point -> or animate
  }

  void Update()
  {
    if (!pausePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)) //when escape is pressed
    {
      Pause();
    }
    else if (pausePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)) //Quit game
    {
      Continue(); //to make sure time related stuff is resumed
      Application.Quit();
    }
    else if (pausePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.C)) //UnPause/continue
    {
      Continue();
    }
    else if (pausePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.L)) //return to Level Select
    {
      Continue(); //to make sure time related stuff is resumed
      LoadingScreenManager.LoadScene(MenuLvlNumber);
    }
  }


  private void Pause()
  {
    Time.timeScale = 0; //turn all time related things off
    pausePanel.SetActive(true);
  }

  private void Continue()
  {
    Time.timeScale = 1; //turn all time related things back on
    pausePanel.SetActive(false);
  }
}