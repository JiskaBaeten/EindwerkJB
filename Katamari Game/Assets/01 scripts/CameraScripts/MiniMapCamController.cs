using UnityEngine;
using System.Collections;

public class MiniMapCamController : MonoBehaviour
{

  public GameObject player;
  private Vector3 offset;
  private int zoomNum = 0;

  void Start()
  {
    offset = transform.position - player.transform.position;
  }

  void LateUpdate()
  {
    transform.position = player.transform.position + offset;
  }

  void Update() //getallen nog aanpassen
  {
    //ZOOMCONTROLS
    if (Input.GetKeyDown(KeyCode.Z)) //to zoom out
    {
      StartCoroutine(ZoomCam(new Vector3(0, 4, 0), 2));
      zoomNum++;
    }

    if (Input.GetKeyDown(KeyCode.C)) //to zoom in
    {
      if (zoomNum > 0) // to make the user doesnt overzoom
      { 
        StartCoroutine(ZoomCam(new Vector3(0, -4, 0), 2));
        zoomNum--;
      }
    }
  }

  IEnumerator ZoomCam(Vector3 endPos, float time) //slowly zoom out, and do this for x seconds
  {
    float elapsedTime = 0;
    Vector3 startPos = offset;
    endPos += offset;

    while (elapsedTime < time)
    {
      offset = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
      elapsedTime += Time.deltaTime;
      yield return 0;
    }
  }

}