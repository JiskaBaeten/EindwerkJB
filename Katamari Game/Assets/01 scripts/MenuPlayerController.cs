using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//stick it to the ball
//controls stuff concerning the player (When it touches a trigger, to make the ball grow, limit how many pickups are shown onto the ball...)
public class MenuPlayerController : MonoBehaviour
{
  public Rigidbody playerRigidBody;
  private Vector3 ballSize;

  //check number in buildsettings
  private int loadParkLevel = 2;
  private int loadStreetLevel = 3; // buildnumbers still have to be changed
  private int loadEarthLevel = 4;  // buildnumbers still have to be changed

  private bool lvlLoadIsTriggered = false;

  public Text comingSoonText;
  public GameObject warningPanel;

  private double timerTime = 0f;

  void Start()
  {
    ballSize = playerRigidBody.transform.localScale; //keep it here just in case other scripts ask about it
  }

  private void Update()
  {
    if (timerTime > 2)
      warningPanel.SetActive(false);

    timerTime += Time.deltaTime;
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

        warningPanel.SetActive(true);
        comingSoonText.text = "Coming soon!";
        timerTime = 0;
      }

      if (triggerLevels.gameObject.tag == "LVL3") //load level 3 - earth -> COMING SOON?
      {
        //LoadingScreenManager.LoadScene(loadEarthLevel);

        warningPanel.SetActive(true);
        comingSoonText.text = "Coming soon!";
        timerTime = 0;
      }
    }
  }
}