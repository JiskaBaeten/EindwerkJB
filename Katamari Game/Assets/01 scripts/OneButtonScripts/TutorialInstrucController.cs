using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInstrucController : MonoBehaviour
{

  public Text instructionText;
  private List<string> instructionListButtons = new List<string>();
  private List<string> instructionListController = new List<string>();
  private byte counter = 0;

  public Text connectionStatusText; //text for player to see if Arduino is connected

  private void Start()
  {
    instructionListButtons.Add("Press up OR num 8 keypad OR move mouse up \n to move forward");
    instructionListButtons.Add("Press down OR num 2 keypad OR move mouse down \n to move backwards");
    instructionListButtons.Add("Press left OR num 4 keypad OR move mouse left \n to turn left");
    instructionListButtons.Add("Press right OR num 6 keypad OR move mouse right \n to turn right");
    instructionListButtons.Add("Check if something is smaller than you, \n by pressing SPACE");

    instructionListController.Add("Roll ball forward to move forward");
    instructionListController.Add("Roll ball backwards to move backwards");
    instructionListController.Add("Turn wheel left to turn left");
    instructionListController.Add("Turn wheel right to turn right");
    instructionListController.Add("Check if something is smaller than you, \n by pressing SPACE");
  }

  void LateUpdate()
  {

    if (Input.GetKeyDown(KeyCode.N))
    {
      if (instructionListButtons.Count - 1 > counter)
        counter++;
    }

    if (Input.GetKeyDown(KeyCode.B))
    {
      if (0 < counter)
        counter--;
    }

    if (connectionStatusText.text == "Connected")
      instructionText.text = instructionListController[counter];
    else if (connectionStatusText.text == "Disconnected")
      instructionText.text = instructionListButtons[counter];
  }
}
