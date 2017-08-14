using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControllerV3 : MonoBehaviour
{
  //orbit the camera around the player

  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset;

  private PlayerController pc = null;
  private Vector3 ballSize = Vector3.zero;

  private MessageReadWrite arduinoScript = null;
  private string serialReadWriteTag = "serialReadWrite";

  public Animator animationController;
  private string beetleTag = "beetle";
  private float speed = 0;

  private int zoomNum = 0;

  void Start()
  {
    arduinoScript = GameObject.FindWithTag(serialReadWriteTag).GetComponent<MessageReadWrite>(); //look for arduinoscript
    animationController = GameObject.FindWithTag(beetleTag).GetComponent<Animator>();

    //used to get the size from the ball from the playerController (read only)
    pc = player.GetComponent<PlayerController>();

    offset = transform.position - player.transform.position;
  }

  void Update()
  {
    //ZOOMCONTROLS
    if (Input.GetKeyDown(KeyCode.Z)) //to zoom out
    {
      StartCoroutine(ZoomCam(new Vector3(0, 1, -2.5f), 2));
      zoomNum++;
    }

    if (Input.GetKeyDown(KeyCode.E)) //to zoom in
    {
      if (zoomNum > 0) // to make the user doesnt overzoom
      {
        StartCoroutine(ZoomCam(new Vector3(0, -1, 2.5f), 2));
        zoomNum--;
      }
    }


    if (pc != null)
    {
      ballSize = pc.SizeBall; //must be updated
    }
  }

  void LateUpdate()
  {
    //turn around the Y-axis
      offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset; //if input is mouse
      animationController.SetFloat("speedHori", Input.GetAxis("Mouse X"));

    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) //if input from arrows
    {
      offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed/2, Vector3.up) * offset;
      animationController.SetFloat("speedHori", Input.GetAxis("Horizontal"));
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
      else {
        if (Input.GetAxis("Mouse X") == 0 && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.Keypad4) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.Keypad6) == false)
        {
          speed = 0;
          animationController.SetFloat("speed", speed);
        }
      }; //when bool = null
    }

    transform.position = player.position + offset;
    transform.LookAt(player.position); //keep on looking where the player is

    speed = 0;
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
    { extraSpeed = 0.3f; }

    speed = 1;
    offset = Quaternion.AngleAxis(-turnSpeed * extraSpeed, Vector3.up) * offset;
    animationController.SetFloat("speedHori", speed);
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
    { extraSpeed = 0.3f; }

    offset = Quaternion.AngleAxis(turnSpeed * extraSpeed, Vector3.up) * offset;
    speed = -1;
    animationController.SetFloat("speedHori", speed);
  }

  IEnumerator ZoomCam(Vector3 endPos, float time) //slowly zoom out, and do this for x seconds
  {
    float elapsedTime = 0;
    Vector3 startPos = offset;
    endPos += offset;

    while (elapsedTime < time)
    {
      offset = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
      elapsedTime += Time.deltaTime;
      yield return 0;
    }
  }

  public Vector3 OffsetCam
  { get { return offset; } }
}
