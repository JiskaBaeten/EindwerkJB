using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {
	public Rigidbody playerRigidBody;
	public float speed;
	public Text SizeText;
	private Vector3 ballSize;
	private Vector3 upSize;
	public GameObject collector;
	public List<GameObject> pickupArray = new List<GameObject>();
  private byte pickUpsShowing = 10;

	void Start() {
		ballSize = playerRigidBody.transform.localScale;
		SetSizeText();
	}

	void FixedUpdate()
	{
    //shows max 10 items on the ball and destroys the oldest one
		if (pickupArray.Count >= pickUpsShowing) {
			GameObject removeMe = new GameObject();
			removeMe = pickupArray[0];
			pickupArray.RemoveAt(0);
			Destroy(removeMe);
		}
	}

	void Update() {
	}

	void OnTriggerEnter(Collider pickup) {
		if (pickup.gameObject.tag == "PickUp") {
      pickup.gameObject.GetComponent<Collider>().isTrigger = false;
      pickup.gameObject.GetComponent<Collider>().enabled = false;
			pickupArray.Add(pickup.gameObject);

			SetGrowthSize(pickup.transform.localScale);
      pickup.gameObject.transform.parent = collector.transform;
			ballSize = ballSize + upSize;
      playerRigidBody.transform.localScale = ballSize; //update ballsize

      SetSizeText();
		}
	}

	void SetSizeText() {
		SizeText.text = "Size: " + ballSize.x.ToString ();
	}

	void SetGrowthSize(Vector3 pickup) { //might be something wrong here
		float min = new float ();
		min = Mathf.Min (pickup.x, Mathf.Min (pickup.y, pickup.z)); //what is this...
		/*upSize.x = (min / ballSize.x) / 8; //why divided by 8
		upSize.y = (min / ballSize.y) / 8;
		upSize.z = (min / ballSize.z) / 8;*/ //set higer to grow less
    upSize.x = (min / ballSize.x) / 12; 
    upSize.y = (min / ballSize.y) / 12;
    upSize.z = (min / ballSize.z) / 12;
  }

  public Vector3 SizeBall //to use the size of the ball in other scripts
  {
     get { return ballSize; }
  }
}