using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//win level with buttonpress -> Cheat
public class WinCheat : MonoBehaviour {

  public Transform playerTransform;
  public GameObject winCube; //is a prefab
  public GameObject addCube;

  private Vector3 playerPos;
  private Quaternion playerRot;

  void Update () {
    if (Input.GetKeyDown(KeyCode.W)) //make cube at position player to trigger a win situation
    {
      playerPos = new Vector3(playerTransform.position.x, playerTransform.position.y + 0.5f, playerTransform.position.z);
      playerRot = playerTransform.rotation;
      Instantiate(winCube, playerPos, playerRot); 
    }

    if (Input.GetKeyDown(KeyCode.X)) //just add cubes that make you grow
    {
      playerPos = new Vector3(playerTransform.position.x, playerTransform.position.y + 0.5f, playerTransform.position.z);
      playerRot = playerTransform.rotation;
      Instantiate(addCube, playerPos, playerRot); 
    }
  }
}
