using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//load highscores for the menuLevel
public class LoadHighscore : MonoBehaviour
{

  public TextMesh lvl1Mesh;
  public TextMesh lvl2Mesh;
  public TextMesh lvl3Mesh;

  private float defaultMaxTime = 3600f;
  private string lvl1Name = "testScene"; //change this name when the official scene is made!!
  private string lvl2Name = "streetScene";
  private string lvl3Name = "worldScene";

  private string convertedTime = "";
  private float minutes = 0f;
  private float seconds = 0f;

  void Start()
  {
    LoadScores();
  }

  void LoadScores()
  {
    if (!PlayerPrefs.HasKey("level " + lvl1Name)) //when it hasn't made a registery for lvl1
    {
      lvl1Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);
    }
    else
    {
      lvl1Mesh.text = ConvertToMinutesAndSeconds(PlayerPrefs.GetFloat("level " + lvl1Name));
    }

    if (!PlayerPrefs.HasKey("level " + lvl2Name)) //when it hasn't made a registery for lvl2 yet
    {
      lvl2Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);
    }
    else
    {
      lvl2Mesh.text = ConvertToMinutesAndSeconds(PlayerPrefs.GetFloat("level " + lvl2Name));
    }

    if (!PlayerPrefs.HasKey("level " + lvl3Name)) //when it hasn't made a registery for lvl3
    {
      lvl3Mesh.text = ConvertToMinutesAndSeconds(defaultMaxTime);
    }
    else
    {
      lvl3Mesh.text = ConvertToMinutesAndSeconds(PlayerPrefs.GetFloat("level " + lvl3Name));
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
