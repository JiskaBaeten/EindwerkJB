using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class cameraController : MonoBehaviour
{
  //orbit the camera around the player
  // --> zoom offset seems wrong
  //add numbers to zoomnumbers!!!!!

  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset; //STILL NEED TO FINETUNE THESE
  private float offsetY = 0.5f;
  private float offsetZ = 5.0f;
  private float offsetZoomOut = 0.5f;
  private float zoomOutSpeed = 5.0f;

  private PlayerController pc = null;
  private Vector3 ballSize = Vector3.zero;

  private List<float> zoomOutNumbers = new List<float>();

  void Start()
  {
    //used to get the size from the ball from the playerController (read only)
    pc = player.GetComponent<PlayerController>();

    //beginoffset for the offset
    offset = new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ);

    //to get all the numbers so the cam knows when to zoom out, TESTS FOR MORE NEEDED
    zoomOutNumbers.Add(2.0f);
    zoomOutNumbers.Add(4.0f);
  }

  void Update()
  {
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
      if (Input.GetKey(KeyCode.Keypad4)) //turn left
      { offset = Quaternion.AngleAxis(-turnSpeed, Vector3.up) * offset; }
      else if (Input.GetKey(KeyCode.Keypad6)) //turn right
      { offset = Quaternion.AngleAxis(turnSpeed, Vector3.up) * offset; }
    }

    transform.position = player.position + offset;
    transform.LookAt(player.position); //keep on looking where the player is
  }

  public void ZoomOut()
  {
    //if ball gets too big for camera
    //turns weird

    //Mathf.Lerp(Camera.main.fieldOfView, 100, 0.1);
    offset += new Vector3(player.position.x, player.position.y + offsetY, player.position.z - offsetZ - offsetZoomOut);

    transform.position = player.position + offset;
  }
}