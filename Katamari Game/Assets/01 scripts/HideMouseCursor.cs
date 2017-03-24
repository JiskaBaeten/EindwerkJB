using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseCursor : MonoBehaviour
{
    private bool showingMouseCursor = true;
  void Update()
  {
    if (Input.GetKeyUp(KeyCode.H))
    {
        showingMouseCursor = !showingMouseCursor;
    }
      
      Cursor.visible = showingMouseCursor;
  }
}
