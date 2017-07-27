using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{

  private bool lvlLoadIsTriggered = false;
  private byte tutorialLevelnumber = 4;

  void Update()
  {

    if (!lvlLoadIsTriggered) //if we haven't started loading, so multiple triggers won't work
    {
      if (Input.GetKeyDown(KeyCode.T))
      {
        lvlLoadIsTriggered = true;
        LoadingScreenManager.LoadScene(tutorialLevelnumber);
      }
    }
  }
}
