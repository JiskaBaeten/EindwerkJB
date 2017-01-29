using UnityEngine;
using System.Collections;

//script to check if ball is bigger than the pickup
public class PickupObject : MonoBehaviour {
	public GameObject playerObject;
	private GameObject pickup;
	private float volumePickup;

	void Start() {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		pickup = this.gameObject;
		pickup.gameObject.tag = "PickUp"; //put this tag onto the object the script is hanging onto
    volumePickup = pickup.transform.localScale.x * pickup.transform.localScale.y * pickup.transform.localScale.z;
  }

	void Update () {
    //volume sphere: r^3 * pi * 4/3 is bigger than the pickup
    //divided by two since I only have the diametre
    if ((((playerObject.transform.localScale.x / 2f) * (playerObject.transform.localScale.x / 2f) * (playerObject.transform.localScale.x / 2f)) * 3.14f * (4 / 3)) > (volumePickup)) {
			pickup.gameObject.GetComponent<Collider> ().isTrigger = true;

		}
	}
}
