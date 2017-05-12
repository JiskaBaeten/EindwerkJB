using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPointLock : MonoBehaviour {
  //made for the point where the beetle needs to look at, but that point isn't allowed to rotate, but it follow ball

  public Transform playerTrans;
  public Transform camer;
	
	void Update () {
    transform.position = new Vector3(playerTrans.position.x, transform.position.y, playerTrans.position.z);
    transform.LookAt(new Vector3(2 * transform.position.x - camer.transform.position.x, 0, 2 * transform.position.z - camer.transform.position.z)); //(2*tran.pos - cam.tran.pos) -> used to invert the lookat
  }
}
