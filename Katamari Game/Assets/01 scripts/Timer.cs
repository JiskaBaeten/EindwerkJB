using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//used to time how long someone is playing the level
public class Timer : MonoBehaviour
{
  private static float totalTime = 0f;
  private static float minutes = 0f;
  private static float seconds = 0f;

  private void Start()
  {
    totalTime = 0f; //to make sure it always starts at zero
  }

  void Update()
  {
    if (!PlayerController.DidWeWin && PlayerController.IsFirstPickedUp) //check the bool in de playercontroller script, havent won yet
    {
      totalTime += Time.deltaTime;
      ConvertToMinutesAndSeconds();
    }
  }

  public static float TotalTime
  {
    get { return totalTime; }
  }

  private void ConvertToMinutesAndSeconds()
  {
    minutes = totalTime / 60;
    seconds = totalTime % 60;

    //to round down minutes and make sure there's nothing behind comma + seconds and milliseconds
    GetComponent<Text>().text = "Time: " + Mathf.Floor(minutes).ToString("F0") + ":" + seconds.ToString("F2");
  }
}
