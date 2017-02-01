using UnityEngine;
using System.Collections;

//puts the pickups onto the collector of the ball
public class AttachPickup : MonoBehaviour {
	public GameObject collector;
	public Rigidbody playerObject;

	void FixedUpdate() {
		collector.transform.localPosition = playerObject.transform.localPosition;
		collector.transform.localRotation = playerObject.transform.localRotation;
	}
}
