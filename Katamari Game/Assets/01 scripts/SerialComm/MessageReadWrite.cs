using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//script used to send and read messages from the arduino
public class MessageReadWrite : MonoBehaviour
{
  public SerialController serialController;
  private string recievedData;

  private long oldNumberEnc1 = 0;
  private long oldNumberEnc2 = 0;
  private long newNumber;

  private const string enc1 = "Encoder1: "; //same string as used in arduino script
  private const string enc2 = "Encoder2: "; //same string as used in arduino script

  public bool? enc1TurnLeft = null; //made nullable for when it has no input
  public bool? enc2TurnLeft = null; //made nullable for when it has no input

  void Start()
  {
    serialController = GameObject.Find("SerialController").GetComponent<SerialController>(); //look for the script
  }

  void Update()
  {
    //recieve data
    recievedData = serialController.ReadSerialMessage(); //read in serialPort from Arduino
    if (recievedData == null) return; //if no message, stop here

    if (recievedData.StartsWith(enc1)) //the first encoder send a message
    {
      CheckLeftOrRight(enc1);
    }
    else if (recievedData.StartsWith(enc2)) //the second encoder send a message
    {
      CheckLeftOrRight(enc2);
    }

    // Check if the message is plain data or a connect/disconnect event.
    if (ReferenceEquals(recievedData, SerialController.SERIAL_DEVICE_CONNECTED))
      Debug.Log("Connection established");
    else if (ReferenceEquals(recievedData, SerialController.SERIAL_DEVICE_DISCONNECTED))
      Debug.Log("Connection attempt failed or disconnection detected");
    else
      Debug.Log("Message arrived: " + recievedData);
  }

  void CheckLeftOrRight(string whichEncoder)
  {
    newNumber = long.Parse(recievedData.Replace(whichEncoder, "")); //remove the actual string en parse the number into a long
    switch (whichEncoder)
    {
      case enc1:
        if (newNumber > oldNumberEnc1) //turn left
        {
          enc1TurnLeft = true;
        }
        else //turn right
        {
          enc1TurnLeft = false;
        }
        oldNumberEnc1 = newNumber;
        break;
      case enc2:
        if (newNumber > oldNumberEnc2) //turn left
        {
          enc2TurnLeft = true;
        }
        else //turn right
        {
          enc2TurnLeft = false;
        }
        oldNumberEnc2 = newNumber;
        break;
      default:
        break;
    }
  }
}
