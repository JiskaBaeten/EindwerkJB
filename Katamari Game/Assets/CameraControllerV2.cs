using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CameraControllerV2 : MonoBehaviour
{
  //orbit the camera around the player
  // --> zoom offset seems wrong
  //add numbers to zoomnumbers!!!!!

  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset; //STILL NEED TO FINETUNE THESE ******
  private float offsetY = 0.5f;
  private float offsetZ = 5.0f;
  private float offsetZoomY = 0.5f;
  private float offsetZoomZ = 0.5f;

  private PlayerController pc = null;
  private Vector3 ballSize = Vector3.zero;

  private List<float> zoomOutNumbers = new List<float>();

  private MessageReadWrite arduinoScript = null;
  private string serialReadWriteTag = "serialReadWrite";

  void Start()
  {
    arduinoScript = GameObject.FindWithTag(serialReadWriteTag).GetComponent<MessageReadWrite>(); //look for aruinoscript

    //used to get the size from the ball from the playerController (read only)
    pc = player.GetComponent<PlayerController>();

    //beginoffset for the offset
    offset = new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ);

    //****to get all the numbers so the cam knows when to zoom out, TESTS FOR MORE NEEDED *****
    zoomOutNumbers.Add(2.0f);
    zoomOutNumbers.Add(4.0f);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      ZoomOut();
    }

    if (pc != null)
    {
      ballSize = pc.SizeBall; //must be updated
    }

    if (zoomOutNumbers.Count > 0) //only do this when list is not empty
    {
      if (zoomOutNumbers[0] <= ballSize.x) //if ball is too big, zoom out
      {
        zoomOutNumbers.RemoveAt(0); //remove current number
        ZoomOut();
      }
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

  public void ZoomOut()
  {
    //if ball gets too big for camera
    //turns weird

    //Mathf.Lerp(Camera.main.fieldOfView, 100, 0.1);
    //  offset += new Vector3(player.position.x, player.position.y + offsetY, player.position.z - offsetZ - offsetZoomOut);
    //offset += new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ);
    offset += new Vector3(player.position.x, player.position.y, player.position.z + offsetZoomZ);

    // transform.position = player.position + offset;
  }

  public Vector3 OffsetCam
  { get { return offset; } }
}