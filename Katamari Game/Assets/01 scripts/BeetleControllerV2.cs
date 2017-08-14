using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleControllerV2 : MonoBehaviour
{

  public GameObject player; //just to get the ballsize property
  private PlayerController pc;

  void Start()
  {
    pc = player.GetComponent<PlayerController>();
  }

  void LateUpdate()
  {
    if (pc != null) //only do this code when the player is ready and loaded
    {
      //local position since it's parented to LockedAtBottomBall
      // transform.localPosition = new Vector3(0, 0, -pc.SizeBall.z / 2); //minus since it needs to be on the opposite side to where the cam is looking at
      transform.localPosition = new Vector3(0, 0, -pc.SizeBall.z / 2);
    }
  }
}
