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
  private Quaternion camRot;
  private float distance;
  private Vector3 testOffset;
  private float testSin;
  private float sinGetal;

  void Start()
  {
    cc = cameraOb.GetComponent<cameraController>();
  }
  void Update()
  {
    beetleOffset = new Vector3(cameraOb.transform.position.x, lockPosition.position.y, cameraOb.transform.position.z);
    //camRot = Quaternion.Euler(cameraOb.transform.rotation.x, cameraOb.transform.rotation.y, cameraOb.transform.rotation.z);

    // transform.position = lockPosition.position - beetleOffset; //beetleoffset is nu recht onder cam
    //transform.RotateAround(lockPosition.position, Vector3.up, camRot);

    //schuine, overstaande nodig -> sinus -> hoek is x rot cam --> overstaande = schuin / sin(hoek in graden) 
    // distance = Vector3.Distance(lockPosition.position, cameraOb.transform.position); //schuine
    distance = cameraOb.transform.position.y - lockPosition.position.y; //schuine
  /* Debug.Log("beetleOff: " + beetleOffset);
    Debug.Log("dist: " + distance);
    Debug.Log("graden: " + cameraOb.transform.rotation.x);
    Debug.Log("graden in rad: " + cameraOb.transform.rotation.x * Mathf.Deg2Rad*100);*/

    //unity werkt met radialen!!!
    if (cameraOb != null)
    {
      testSin = Mathf.Sin((cameraOb.transform.rotation.x) * Mathf.Deg2Rad*100) * distance; //*100 since degrees are in comma
    }
    //enkel nog te ver
    transform.position = beetleOffset - new Vector3(0f, 0f, testSin);
    //Debug.Log("offset: " + beetleOffset);
  // Debug.Log("testsin: " + testSin);

    //rotates with cam so beetle is always looking at the ball
   transform.LookAt(lockPosition.position);
  }
}