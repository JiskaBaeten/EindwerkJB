using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Rigidbody playerRigidBody;
	public float speed;
	public GameObject mainCamera;
	public GameObject playerContainer;
		void FixedUpdate()
		{
      if (Input.GetKey(KeyCode.UpArrow))
      {
			playerRigidBody.AddForce (mainCamera.transform.forward * 1.5f * speed * Time.deltaTime);
		}
      if (Input.GetKey(KeyCode.DownArrow))
      {
			playerRigidBody.AddForce(-mainCamera.transform.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			playerRigidBody.AddForce(-mainCamera.transform.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			playerRigidBody.AddForce(mainCamera.transform.right * speed * Time.deltaTime);
		}
		}
	}
