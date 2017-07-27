using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {

  public Text quitText;
  public GameObject warningPanel;

  void Start()
  {
    quitText.text = "";
    warningPanel.SetActive(false);
  }

  void Update() {

    if(Input.GetKeyDown(KeyCode.Escape))
    {
      warningPanel.SetActive(true);
      quitText.text = "Do you want to quit the game? \n Y or N?";
    }

    if (Input.GetKeyDown(KeyCode.Y) && quitText.text == "Do you want to quit the game? \n Y or N?")
    {
      warningPanel.SetActive(false);
      Application.Quit();
    }
    else if (Input.GetKeyDown(KeyCode.N) && quitText.text == "Do you want to quit the game? \n Y or N?")
    {
      quitText.text = "";
      warningPanel.SetActive(false);
    }
   
  }
}
