using UnityEngine;
using System.Collections;

//add to PlayerContainer
//to move the ball of poop
//to rotate, see cameraController
public class MovePlayer : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  public GameObject mainCamera;
  private byte moveSpeed = 50;
  private float rotation;

  private MessageReadWrite arduinoScript = null;
  private string serialReadWriteTag = "serialReadWrite";

  public Animator animationController;
  private string beetleTag = "beetle";
  float speed;

  void Start()
  {
    arduinoScript = GameObject.FindWithTag(serialReadWriteTag).GetComponent<MessageReadWrite>(); //look for arduinoscript
    animationController = GameObject.FindWithTag(beetleTag).GetComponent<Animator>();
  }

  void FixedUpdate()
  {
    //always roll into the direction the cam is facing (mainCam.transform.forward)
    if (Input.GetAxis("Mouse Y") > 0 || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8)) //forward
    {
      animationController.SetFloat("speed", speed);
      MoveForward("other");
    }
    if (Input.GetAxis("Mouse Y") < 0 || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2)) //backward
    {
      animationController.SetFloat("speed", speed);
      MoveBackward("other");
    }

    if (arduinoScript != null) //when the script was found
    { //input from arduino
      if (arduinoScript.enc1TurnLeft == true)
      {
        MoveForward("arduino");
      }
      else if (arduinoScript.enc1TurnLeft == false)
      {
        MoveBackward("arduino");
      }
      else
      {
        if (Input.GetAxis("Mouse Y") == 0 && Input.GetKey(KeyCode.DownArrow) == false && Input.GetKey(KeyCode.Keypad2) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.Keypad8) == false)
        {
          speed = 0;
          animationController.SetFloat("speed", speed);
        }
      } //when null (since it's a nullable bool)
    }
  }

  void MoveForward(string whichInput) //we move faster forward than backwards
  {
    float extraSpeed = 1f;

    if (whichInput == "arduino")
    {
      extraSpeed = 10f;
      arduinoScript.enc1TurnLeft = null; //to make sure that the bool is reset
    }
    else if (whichInput == "other") //if it's not arduino
    { extraSpeed = 1.5f; }

    playerRigidBody.AddForce(mainCamera.transform.forward * extraSpeed * moveSpeed * Time.deltaTime);
    speed = 1;
    animationController.SetFloat("speed", speed);
  }

  void MoveBackward(string whichInput)
  {
    float extraSpeed = 1f;

    if (whichInput == "arduino")
    {
      arduinoScript.enc1TurnLeft = null; //to make sure that the bool is reset
      extraSpeed = 5f;
    }
    else if (whichInput == "other") //if it's not arduino
    { extraSpeed = 1f; }

    playerRigidBody.AddForce(-mainCamera.transform.forward * extraSpeed * moveSpeed * Time.deltaTime);
    speed = -1;
    animationController.SetFloat("speed", speed);
  }
}
