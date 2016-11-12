using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{
  //orbit the camera around the player
  // --> still need to zoom out when you get bigger

  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset;
  private Vector3 offsetDist;
  private float offsetY = 0.5f;
  private float offsetZ = 5.0f;

  void Start()
  {
    //begindistance for the offset
    offsetDist = new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ);
  }

  void LateUpdate()
  {
    //turn around the Y-axis
    offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetDist;
    transform.position = player.position + offset;
    transform.LookAt(player.position); //keep on looking where the player is
  }

  public void ZoomOut()
  {
    //if ball gets too big for camera
    //make new vector?
  }
}