using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//to play the cutscene and load the next scene
public class movieController : MonoBehaviour
{

  public MovieTexture movTexture;
  private AudioSource movMusic;
  private bool loadingStarted = false;

  private byte parkLevel = 3;

  void Start()
  {
    ///make movie play on rawimage and load in music from object
    GetComponent<RawImage>().texture = movTexture;
    movMusic = GetComponent<AudioSource>();

    // this line of code will make the Movie Texture begin playing
    movTexture.Play();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space)) //stop video & music pre-emptivly
    {
      movTexture.Stop();
      movMusic.Stop();
    }

    if (!movTexture.isPlaying)
    {
      if (SceneManager.GetActiveScene().name == "Lvl1CutScene")
      {
        if (!loadingStarted) //load playable Level 1
        {
          loadingStarted = false;
          LoadingScreenManager.LoadScene(parkLevel);
        }
      }
    }
  }
}
