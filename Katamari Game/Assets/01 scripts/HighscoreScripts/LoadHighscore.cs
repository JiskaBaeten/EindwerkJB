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

  void Start()
  {
    LoadScores();
  }

  void LoadScores()
  {
    if (!PlayerPrefs.HasKey("level " + lvl1Name)) //when it hasn't made a registery for lvl1
    {
      lvl1Mesh.text = defaultMaxTime.ToString("F2") + " s";
    }
    else
    {
      lvl1Mesh.text = PlayerPrefs.GetFloat("level " + lvl1Name).ToString("F2") + " s"; //load the highscore for lvl1
    }

    if (!PlayerPrefs.HasKey("level " + lvl2Name)) //when it hasn't made a registery for lvl2 yet
    {
      lvl2Mesh.text = defaultMaxTime.ToString("F2") + " s";
    }
    else
    {
      lvl2Mesh.text = PlayerPrefs.GetFloat("level " + lvl2Name).ToString("F2") + " s"; //load the highscore for lvl2
    }

    if (!PlayerPrefs.HasKey("level " + lvl3Name)) //when it hasn't made a registery for lvl3
    {
      lvl3Mesh.text = defaultMaxTime.ToString("F2") + " s";
    }
    else
    {
      lvl3Mesh.text = PlayerPrefs.GetFloat("level " + lvl3Name).ToString("F2") + " s"; //load the highscore for lvl3
    }
  }
}
