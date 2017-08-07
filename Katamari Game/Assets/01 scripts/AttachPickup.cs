using UnityEngine;
using System.Collections;

//puts the pickups onto the collector of the ball
public class AttachPickup : MonoBehaviour {
	public GameObject pickupHolder;
	public Rigidbody playerObject;

	void FixedUpdate() {
    pickupHolder.transform.localPosition = playerObject.transform.localPosition;
    pickupHolder.transform.localRotation = playerObject.transform.localRotation;
	}
}
