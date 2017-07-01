using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {

  public Text quitText;

  void Start()
  {
    quitText.text = "";
  }

  void Update() {

    if(Input.GetKeyDown(KeyCode.Escape))
    {
      quitText.text = "Do you want to quit the game? \n Y or N?";
    }

    if (Input.GetKeyDown(KeyCode.Y) && quitText.text == "Do you want to quit the game? \n Y or N?")
    {
      Application.Quit();
    }
    else if (Input.GetKeyDown(KeyCode.N) && quitText.text == "Do you want to quit the game? \n Y or N?")
    {
      quitText.text = "";
    }
   
  }
}
