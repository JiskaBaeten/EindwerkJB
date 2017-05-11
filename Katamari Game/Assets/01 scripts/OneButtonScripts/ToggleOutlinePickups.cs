using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to pickups!!
//trigger outlines when smaller + playerinput (buttonpress)
//doesnt work perfectly on meshes!!! fix!!

public class ToggleOutlinePickups : MonoBehaviour
{
  private PickupObject po = null;
  Shader outlineShader;
  Shader normalShader;
  bool outlineVisible = false;
  bool ballMapShowing = false;

  private void Start()
  {
    outlineShader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
    normalShader = Shader.Find("Standard");
    po = this.GetComponent<PickupObject>();
    ballMapShowing = false;
  }

  private void Update()
  {
    if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) //toggle outline
    {
      outlineVisible = !outlineVisible;
    }

    if (outlineVisible) //show outline when space/mouse has been pressed
    {
      if (po.ImSmaller && this.gameObject.tag != "StuckToBall") // -> outline when smaller and not stuck to ball
      {
        this.GetComponent<Renderer>().material.shader = outlineShader;
      }
      else if (this.gameObject.tag == "StuckToBall") //if stuck to container > no outline
      {
        this.GetComponent<Renderer>().material.shader = normalShader;
      }
    }
    else //hide outline
    {
      this.GetComponent<Renderer>().material.shader = normalShader;
    }


    //for the minimap
    if (po.ImSmaller && this.gameObject.tag != "StuckToBall" && !ballMapShowing)
    {
      if (transform.childCount > 0)
      {
        Debug.Log("Ball Showing!");
        transform.GetChild(0).gameObject.SetActive(true);
        ballMapShowing = true;
      }
    }
  }
}
