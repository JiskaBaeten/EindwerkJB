using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//used to time how long someone is playing the level
public class Timer : MonoBehaviour
{
  float totalTime = 0f;

  private void Start()
  {
    totalTime = 0f; //to make sure it always starts at zero
  }

  void Update()
  {
    if (!PlayerController.didWeWin) //check the bool in de playercontroller script, havent won yet
    { 
    totalTime += Time.deltaTime;
    GetComponent<Text>().text = "Time: " + totalTime.ToString("F2"); //with 2 decimals
    }
  }

}
