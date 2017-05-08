using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideMouseCursor : MonoBehaviour
{
  private bool showingMouseCursor = true;
  private Text textToShow;

  void Start()
  {
    textToShow = GetComponent<Text>(); //get textcomponent of object attached to
  }

  void Update()
  {
    if (Input.GetKeyUp(KeyCode.H))showingMouseCursor = !showingMouseCursor; //toggle on/off

    if (showingMouseCursor) textToShow.text = "H to hide cursor";
    else textToShow.text = "H to unhide cursor";
    Cursor.visible = showingMouseCursor; //toggle on/of
  }
}
