using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{
  //orbit the camera around the player
  // --> still need to zoom out when you get bigger

  private float turnSpeed = 4.0f;
  public Transform player;

  private Vector3 offset;
  private float offsetY = 0.5f;
  private float offsetZ = 5.0f;
  private float offsetZoomOut = 0.5f;
  private float zoomOutSpeed = 5.0f;

  private PlayerController pc = null;
  private Vector3 ballSize = Vector3.zero;

  void Start()
  {
    //used to get the size from the ball from the playerController (read only)
    pc = player.GetComponent<PlayerController>();

    //beginoffset for the offset
    offset = new Vector3(player.position.x, player.position.y + offsetY, player.position.z + offsetZ);
  }

  void Update()
  {
    ballSize = pc.SizeBall; //must be updated
    Debug.Log("cc" +ballSize);
    if (ballSize.x % 2 == 0 && ballSize.x != 1)
    {
      ZoomOut();
    }
  }

  void LateUpdate()
  {
    //turn around the Y-axis
    offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
    transform.position = player.position + offset;
    transform.LookAt(player.position); //keep on looking where the player is
  }

   public void ZoomOut()
   {
    //if ball gets too big for camera
    offset += Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) *  new Vector3(player.position.x, player.position.y + offsetY + offsetZoomOut, player.position.z + offsetZ + offsetZoomOut);

    transform.position = player.position + offset;
   }
}