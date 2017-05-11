using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//used to time how long someone is playing the level
public class Timer : MonoBehaviour
{
  private static float totalTime = 0f;

  private void Start()
  {
    totalTime = 0f; //to make sure it always starts at zero
  }

  void Update()
  {
    if (!PlayerController.DidWeWin && PlayerController.IsFirstPickedUp) //check the bool in de playercontroller script, havent won yet
    {
      totalTime += Time.deltaTime;
      GetComponent<Text>().text = "Time: " + totalTime.ToString("F2"); //with 2 decimals
    }
  }

  public static float TotalTime
  {
    get { return totalTime; }
  }

}
