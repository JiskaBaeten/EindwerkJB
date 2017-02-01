using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

  float totalTime = 0f;

  void Update()
  {
    totalTime += Time.deltaTime;
    GetComponent<Text>().text = "Time: " + totalTime.ToString("F2"); //with 2 decimals
  }
 
}
