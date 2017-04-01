﻿using UnityEngine;
using System.Collections;

//putting this here just in case the scripts ask for it
public class MessageListener : MonoBehaviour
{

  // Invoked when a line of data is received from the serial device.
  void OnMessageArrived(string msg)
  {

  }

  // Invoked when a connect/disconnect event occurs. The parameter 'success'
  // will be 'true' upon connection, and 'false' upon disconnection or
  // failure to connect.
  void OnConnectionEvent(bool success)
  {

  }
}