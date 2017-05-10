using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//stick it to the ball
//controls stuff concerning the player (When it touches a trigger, to make the ball grow, limit how many pickups are shown onto the ball...)
// SPEED???
//MAKE VISUALS LOAD SCREEN
public class MenuPlayerController : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  public float speed; //SAME CONCERNING THIS SPEED
  private Vector3 ballSize;

  //check number in buildsettings
  private int loadParkLevel = 2;
  private int loadStreetLevel = 3;
  private int loadEarthLevel = 4;

  private bool lvlLoadIsTriggered = false;

  public Text comingSoonText;

  void Start()
  {
    ballSize = playerRigidBody.transform.localScale; //keep it here just in case other scripts ask about it
  }

  void OnTriggerEnter(Collider triggerLevels)//don't forget to turn trigger on!!
  {
    if (!lvlLoadIsTriggered) //if we haven't started loading, so multiple triggers won't work
    {
      if (triggerLevels.gameObject.tag == "LVL1") //load level 1 - park
      {
        lvlLoadIsTriggered = true;
        LoadingScreenManager.LoadScene(loadParkLevel);
      }

      if (triggerLevels.gameObject.tag == "LVL2") //load level 2 - street -> COMING SOON?
      {
        //LoadingScreenManager.LoadScene(loadStreetLevel);
        Debug.Log("Touched LVL STREET!");
        //comingSoonText.text = "Coming soon!";
      }

      if (triggerLevels.gameObject.tag == "LVL3") //load level 3 - earth -> COMING SOON?
      {
        //LoadingScreenManager.LoadScene(loadEarthLevel);
        Debug.Log("Touched LVL EARTH!");
        //comingSoonText.text = "Coming soon!";
      }
    }
  }
}