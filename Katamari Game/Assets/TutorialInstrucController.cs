using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInstrucController : MonoBehaviour
{

  public Text instructionText;
  private List<string> instructionList = new List<string>();
  private byte counter = 0;

  private void Start()
  {
    instructionList.Add("Press up OR num 8 keypad OR move mouse up OR roll ball forward to move forward");
    instructionList.Add("Press down OR num 2 keypad OR move mouse down OR roll ball backwards to move backwards");
    instructionList.Add("Press left OR num 4 keypad OR move mouse left OR turn wheel left to turn left");
    instructionList.Add("Press right OR num 6 keypad OR move mouse right OR turn wheel right to turn right");
    instructionList.Add("Check if something is smaller than you, by pressing SPACE");

    instructionText.text = instructionList[counter];
  }

  void Update()
  {

    if (Input.GetKeyDown(KeyCode.N))
    {
      if (instructionList.Count-1 > counter)
      counter++;
    }

    if (Input.GetKeyDown(KeyCode.B))
    {
      if (0 < counter)
        counter--;
    }
    instructionText.text = instructionList[counter];
  }
}
