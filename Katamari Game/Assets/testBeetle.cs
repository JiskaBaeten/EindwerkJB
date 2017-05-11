using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBeetle : MonoBehaviour {

  public GameObject lockedPos;
  private Vector3 offset;
  public GameObject ballSize;

	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
   // this.transform.position = new Vector3(lockedPos.transform.position.x + ballSize.transform.localScale.x / 2, 0, lockedPos.transform.position.z + ballSize.transform.localScale.z / 2);
  }
}
