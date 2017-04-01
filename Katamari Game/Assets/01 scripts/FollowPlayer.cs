using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  //used for the beetle following the ball, rotates with cam
  //DOESN't WORK YET

  public GameObject player;
  public GameObject cam;
  private Vector3 beetleSize;

  void Start()
  {
    beetleSize = this.transform.localScale;

  }
  void Update()
  {
    this.transform.localScale = beetleSize; //so the beetle doesn't grow along
    this.transform.position = player.transform.position + cam.transform.position;
  }
}