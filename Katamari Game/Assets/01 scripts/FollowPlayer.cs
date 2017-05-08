using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  //used for the beetle following the ball, rotates with cam
  //DOESN't WORK YET

  public Transform lockPosition;
  public GameObject cameraOb;

  private Vector3 offset;
  private Vector3 beetleOffset;

  private cameraController cc;
  private float distance = 0;

  void Start()
  {
    cc = cameraOb.GetComponent<cameraController>();    
  }
  void Update()
  {
    distance = Vector3.Distance(lockPosition.position, cameraOb.transform.position);
    if (cc != null) offset = cc.OffsetCam / 2;

    //Debug.Log("distance" + distance);
    //beetleOffset = new Vector3(offset.x, -0.5f, offset.z);
    //************ afstand nog ni goe
    beetleOffset = new Vector3(cameraOb.transform.position.x-distance*2, lockPosition.position.y, cameraOb.transform.position.z-distance);
    //Debug.Log(beetleOffset);
    transform.position = lockPosition.position + beetleOffset;

    //rotates with cam so beetle is always looking at the ball
    transform.LookAt(lockPosition.position);
  }
}