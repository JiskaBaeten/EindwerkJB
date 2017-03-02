using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//controls stuff concerning the player (When it touches a trigger, to make the ball grow, limit how many pickups are shown onto the ball...)
public class PlayerController : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  public float speed;
  public Text SizeText;
  public float scaleToCm = 100.0f; //to give the player a realistic number to work with
  private Vector3 ballSize;
  private Vector3 upSize;
  private byte growSize = 6; //so it grows not too fast (1/3 of the object in every direction)

  public GameObject collector;
  public List<GameObject> pickupArray = new List<GameObject>();
  private byte pickUpsShowing = 10; //limits how many objects that stay visible on the ball

  public Text winText;
  public static bool areWePlaying;

  void Start()
  {
    ballSize = playerRigidBody.transform.localScale;
    SetSizeText();
    winText.text = ""; //make sure it's empty at the start
    areWePlaying = true;
  }

  void OnTriggerEnter(Collider pickup)
  {
    if (pickup.gameObject.tag.StartsWith("PickUp"))
    {
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

    if (pickup.gameObject.tag == "PickUpWin")
    {
      winText.text = "You Win!";
      areWePlaying = false;
    }
  }

  void SetSizeText() //shows 
  {
    ///float sizeForText = ballSize.x * scaleToCm; //so the player has a realistic size to think about
    float sizeForText = ballSize.x;
    SizeText.text = "Size: " + sizeForText.ToString("F2") + " cm";
  }

  void SetGrowthSize(Vector3 pickup)
  {
    float average = new float();
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