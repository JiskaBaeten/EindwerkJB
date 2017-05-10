using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//reset highscores with buttonPress in menuLevel
public class ResetHighscores : MonoBehaviour
{
  public Text warningText;
  private bool isWarningShowing = false;

  public TextMesh lvl1Mesh;
  public TextMesh lvl2Mesh;
  public TextMesh lvl3Mesh;

  private float defaultMaxTime = 3600f;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      warningText.text = "Are you sure you want to reset ALL highscores? \n Y or N";
      isWarningShowing = true;
    }

    if (isWarningShowing)
    {
      if (Input.GetKeyDown(KeyCode.Y))
      {
        PlayerPrefs.DeleteAll(); //delete all keys
        lvl1Mesh.text = defaultMaxTime.ToString("F2") + " s";
        lvl2Mesh.text = defaultMaxTime.ToString("F2") + " s";
        lvl3Mesh.text = defaultMaxTime.ToString("F2") + " s";

        warningText.text = "";
        isWarningShowing = false;
      }
      else if (Input.GetKeyDown(KeyCode.N))
      {
        warningText.text = "";
        isWarningShowing = false;
      }
    }
  }
}
