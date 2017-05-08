using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPointLock : MonoBehaviour {
  //made for the point where the beetle needs to look at, but that point isn't allowed to rotate, but it follow ball

  public Transform playerTrans;

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
    transform.position = new Vector3(playerTrans.position.x, transform.position.y, playerTrans.position.z);
    transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
  }
}
