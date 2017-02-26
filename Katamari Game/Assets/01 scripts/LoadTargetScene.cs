using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTargetScene : MonoBehaviour { //werkt wel op PC
  public int numStartUpScene = 1;
  public int secondsToWait = 1;

  private void Start()
  {
     StartCoroutine("WaitAMoment");
  }

  IEnumerator WaitAMoment()
  {
    yield return new WaitForSeconds(secondsToWait); //wait till Loading is ready too
    LoadTarget();
  }

  public void LoadTarget()
  {
    LoadingScreenManager.LoadScene(numStartUpScene);
  }
}
