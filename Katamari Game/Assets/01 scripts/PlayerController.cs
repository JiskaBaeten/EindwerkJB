using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//controls stuff concerning the player (When it touches a trigger, to make the ball grow, limit how many pickups are shown onto the ball...)
// PUBLIC SPEED???
public class PlayerController : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  public float speed; //DOES THIS SPEED DO ANYTHING?
  public Text SizeText;
  public float scaleToCm = 100.0f; //to give the player a realistic number to work with
  private Vector3 ballSize;
  private Vector3 upSize;
  private byte growSize = 6; //so it grows not too fast (1/3 of the object in every direction)

  //variables for picking up objects
  public GameObject collector;
  public List<GameObject> pickupArray = new List<GameObject>();
  private byte pickUpsShowing = 10; //limits how many objects that stay visible on the ball

  public Text winText;
  public static bool didWeWin;
  private bool lvlLoadIsTriggered = false;
  private byte loadMenuLevel = 0;

  AudioSource audioRolledUp; //sound when rolled up

  void Start()
  {
    ballSize = playerRigidBody.transform.localScale;
    SetSizeText();
    winText.text = ""; //make sure it's empty at the start
    didWeWin = false;
  }

  void Update()
  {
    CheckifWon();
  }

  void OnTriggerEnter(Collider pickup)
  {

    if (pickup.gameObject.tag == "PickUpWin") //check if it's a winning object first
    {
      winText.text = "You Win! \n Press space or left click to continue...";
      didWeWin = true;
    }

    if (pickup.gameObject.tag.StartsWith("PickUp")) //all tags that start with Pickup, so PickupWin is included
    {
      pickup.gameObject.GetComponent<Collider>().isTrigger = false;
      pickup.gameObject.GetComponent<Collider>().enabled = false;
      pickup.gameObject.tag = "StuckToBall";
      pickupArray.Add(pickup.gameObject);
      audioRolledUp = pickup.gameObject.GetComponent<AudioSource>();
      audioRolledUp.Play(); //play sound when rolled up

      LimitShownObjects();

      SetGrowthSize(pickup.transform.localScale);
      pickup.gameObject.transform.parent = collector.transform;

      ballSize = ballSize + upSize;
      playerRigidBody.transform.localScale = ballSize; //update ballsize

      SetSizeText(); //update sizeText
    }

  }

  void SetSizeText() 
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

  void CheckifWon()
  {
    if (didWeWin) //check if we won so we can return to the menu with buttonpress
    {
      if (!lvlLoadIsTriggered) //if we haven't started loading, so multiple triggers won't work
      {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
          lvlLoadIsTriggered = true;
          LoadingScreenManager.LoadScene(loadMenuLevel);
        }
      }
    }
  }

  public Vector3 SizeBall //to use the size of the ball in other scripts
  {
    get { return ballSize; }
  }
}