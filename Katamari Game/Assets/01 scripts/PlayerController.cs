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
  private byte pickUpsShowing = 10; //limits how many objects that stay visible on the ball
  private byte growSize = 6; //so it grows not too fast (1/3 of the object in every direction)

	void Start() {
		ballSize = playerRigidBody.transform.localScale;
		SetSizeText();
	}

	void OnTriggerEnter(Collider pickup) {
		if (pickup.gameObject.tag == "PickUp") {
      pickup.gameObject.GetComponent<Collider>().isTrigger = false;
      pickup.gameObject.GetComponent<Collider>().enabled = false;
			pickupArray.Add(pickup.gameObject);

      LimitShownObjects();

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

	void SetGrowthSize(Vector3 pickup) {
		float average = new float ();
    average = (pickup.x + pickup.y + pickup.z) / 3; 

    upSize.x = (average / ballSize.x) / growSize; 
    upSize.y = (average / ballSize.y) / growSize;
    upSize.z = (average / ballSize.z) / growSize;
  }

  void LimitShownObjects()
  {
    //shows max x [see pickUpShowing] items on the ball and destroys the oldest one
    if (pickupArray.Count > pickUpsShowing)
    {
      Destroy(pickupArray[0].gameObject); //destroy oldest
      pickupArray.RemoveAt(0); //remove null from list
    }
  }

  public Vector3 SizeBall //to use the size of the ball in other scripts
  {
     get { return ballSize; }
  }
}