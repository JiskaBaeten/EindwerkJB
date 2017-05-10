using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//win level with buttonpress -> Cheat
public class WinCheat : MonoBehaviour {

  public Transform playerTransform;
  public GameObject winCube; //is a prefab
  private Vector3 playerPos;
  private Quaternion playerRot;

  void Update () {
    if (Input.GetKeyDown(KeyCode.W))
    {
      playerPos = playerTransform.position;
      playerRot = playerTransform.rotation;
      Instantiate(winCube, playerPos, playerRot); //make cube at position player to trigger a win situation
    }
	}
}
