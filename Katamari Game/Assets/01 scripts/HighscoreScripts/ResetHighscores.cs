using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//reset highscores with buttonPress in menuLevel
public class ResetHighscores : MonoBehaviour
{
  public Text warningText;
  public GameObject warningPanel;
  private bool isWarningShowing = false;

  public TextMesh lvl1Mesh;
  public TextMesh lvl2Mesh;
  public TextMesh lvl3Mesh;

  private float defaultMaxTime = 3600f;
  private float minutes;
  private float seconds;
  private string convertedTime;

  private void Start()
  {
    warningPanel.SetActive(false);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      warningPanel.SetActive(true);
      warningText.text = "Are you sure you want to reset \n ALL highscores? \n  Y or N";
      isWarningShowing = true;
    }

    if (isWarningShowing)
    {
      if (Input.GetKeyDown(KeyCode.Y))
      {
        PlayerPrefs.DeleteAll(); //delete all keys
        lvl1Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);
        lvl2Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);
        lvl3Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);

        warningText.text = "";
        isWarningShowing = false;
        warningPanel.SetActive(false);
      }
      else if (Input.GetKeyDown(KeyCode.N))
      {
        warningText.text = "";
        isWarningShowing = false;
        warningPanel.SetActive(false);
      }
    }
  }

  string ConvertToMinutesAndSeconds(float timeToConvert)
  {

    minutes = timeToConvert / 60;
    seconds = timeToConvert % 60;

    //to round down minutes and make sure there's nothing behind comma + seconds and milliseconds
    return convertedTime = Mathf.Floor(minutes).ToString("F0") + ":" + seconds.ToString("F2");
  }
}
