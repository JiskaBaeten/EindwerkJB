using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//turn music on/off with buttonpress
public class ToggleMusic : MonoBehaviour {

  private bool musicOn = true;
  private AudioSource bgMusic;
  private Text textToShow;

  void Start()
  {
    textToShow = this.GetComponent<Text>();
    bgMusic = this.GetComponent<AudioSource>();
  }

  void Update()
  {
    if (Input.GetKeyUp(KeyCode.M)) musicOn = !musicOn; //toggle on/off

    
    if (musicOn) //unpause music
    {
      bgMusic.UnPause();
      textToShow.text = "M to turn music off";
    }
    else //pause music
    {
      bgMusic.Pause();
      textToShow.text = "M to turn music on";
    }
  }
}
