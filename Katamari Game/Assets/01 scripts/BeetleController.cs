using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BeetleController : MonoBehaviour
{
  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset; //STILL NEED TO FINETUNE THESE ******
  private float offsetY = 0.5f;
  private float offsetZ = 5.0f;

  private PlayerController pc = null;
  private Vector3 ballSize = Vector3.zero;

  private MessageReadWrite arduinoScript = null;
  private string serialReadWriteTag = "serialReadWrite";

  void Start()
  {
    arduinoScript = GameObject.FindWithTag(serialReadWriteTag).GetComponent<MessageReadWrite>(); //look for aruinoscript

    //used to get the size from the ball from the playerController (read only)
    pc = player.GetComponent<PlayerController>();
  }

  void Update()
  {
    if (pc != null)
    {
      ballSize = pc.SizeBall; //must be updated
      //offset = new Vector3(player.position.x, -ballSize.y/2, player.position.z);
      offset = new Vector3(player.position.x /5 + ballSize.x / 2,  -ballSize.y / 2, player.position.z / 5 + ballSize.z/2);
    }
  }

  void LateUpdate()
  {
    //turn around the Y-axis
    offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset; //if input is mouse

    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) //if input from arrows
    {
      offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offset;
    }

    if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Keypad6)) //if input from numkeys
    {
      if (Input.GetKey(KeyCode.Keypad4)) { TurnLeft("keyPad"); }
      else if (Input.GetKey(KeyCode.Keypad6)) { TurnRight("keyPad"); }
    }

    if (arduinoScript != null) //when the script was found
    { //input from arduino
      if (arduinoScript.enc2TurnLeft == true) { TurnLeft("arduino"); }
      else if (arduinoScript.enc2TurnLeft == false) { TurnRight("arduino"); }
      else { }; //when bool = null
    }

    transform.position = player.position + offset;
    transform.LookAt(player.position); //keep on looking where the player is
  }

  //used for numpadkeys and arduino
  void TurnLeft(string whichInput)
  {
    float extraSpeed = 1f;

    if (whichInput == "arduino")
    {
      arduinoScript.enc2TurnLeft = null; //to make sure that the bool is reset
      extraSpeed = 5f;
    }
    else if (whichInput == "keyPad") //input is keypad
    { extraSpeed = 1f; }

    offset = Quaternion.AngleAxis(-turnSpeed * extraSpeed, Vector3.up) * offset;
  }

  void TurnRight(string whichInput)
  {
    float extraSpeed = 1f;

    if (whichInput == "arduino")
    {
      arduinoScript.enc2TurnLeft = null; //to make sure that the bool is reset
      extraSpeed = 5f;
    }
    else if (whichInput == "keyPad") //input is keypad
    { extraSpeed = 1f; }

    offset = Quaternion.AngleAxis(turnSpeed * extraSpeed, Vector3.up) * offset;
  }
}