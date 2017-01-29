using UnityEngine;
using System.Collections;

//to move the ball of poop
//to rotate, see cameraController
public class MovePlayer : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  public GameObject mainCamera;
  private byte moveSpeed = 50;
  private float rotation;

  void FixedUpdate()
  {
    if (Input.GetAxis("Mouse Y") > 0 || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8)) //if the mouse is moving forward
    {
      //*1.5f since it moves faster forward than backward and by using this, we always roll in the direction the cam is facing at
      playerRigidBody.AddForce(mainCamera.transform.forward * 1.5f * moveSpeed * Time.deltaTime);
      //  playerRigidBody.AddTorque(mainCamera.transform.forward * 1.5f * moveSpeed * Time.deltaTime);
    }
    if (Input.GetAxis("Mouse Y") < 0 || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2)) //if the mouse is moving backward
    {
      playerRigidBody.AddForce(-mainCamera.transform.forward * moveSpeed * Time.deltaTime);
      // playerRigidBody.AddTorque(-mainCamera.transform.forward * moveSpeed * Time.deltaTime);
    }
  }
}
