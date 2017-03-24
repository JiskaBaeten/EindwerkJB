using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to pickups
//should trigger outlines when smaller + playerinput
//doesnt work perfectly on meshes!!! fix!!
public class ToggleOutlinePickups : MonoBehaviour
{
  private PickupObject po = null;
  Shader outlineShader;
  Shader normalShader;
  bool outlineVisible = false;

  private void Start()
  {
    outlineShader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
    normalShader = Shader.Find("Standard");
    po = this.GetComponent<PickupObject>();
  }

  private void Update()
  {
    if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonUp(0))
    {
      outlineVisible = !outlineVisible;
    }

    if (outlineVisible) //show outline when space/mouse has been pressed
    {
      if (po.ImSmaller) // -> outline
      {
        this.GetComponent<Renderer>().material.shader = outlineShader;
      }
      /*
      else if (this is stuck to pickupcontainer) //if stuck to container, it doesn't need an outline
      {
        this.GetComponent<Renderer>().material.shader = normalShader;
      }
       */
    }
    else //hide outline
    {
      this.GetComponent<Renderer>().material.shader = normalShader;
    }
  }
}
