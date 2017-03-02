/* LoadingScreenManager
// --------------------------------
// built by Martin Nerurkar (http://www.martin.nerurkar.de)
// for Nowhere Prophet (http://www.noprophet.com)
//
// Licensed under GNU General Public License v3.0
// http://www.gnu.org/licenses/gpl-3.0.txt 
// URL: https://www.youtube.com/watch?v=xJQXoG3caGc */

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
