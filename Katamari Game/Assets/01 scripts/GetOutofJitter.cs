using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutofJitter : MonoBehaviour {


	void LateUpdate () {
    if (Input.GetKeyUp(KeyCode.P))
    {
      this.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
	}
}
