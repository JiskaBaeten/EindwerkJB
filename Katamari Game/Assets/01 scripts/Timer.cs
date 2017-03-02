using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//used to time how long someone is playing the level
public class Timer : MonoBehaviour
{

  float totalTime = 0f;

  void Update()
  {
    if (PlayerController.areWePlaying) //check the bool in de playercontroller script
    { 
    totalTime += Time.deltaTime;
    GetComponent<Text>().text = "Time: " + totalTime.ToString("F2"); //with 2 decimals
    }
  }

}
