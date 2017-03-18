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
  bool imOutlined = false;
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

    if (outlineVisible)
    {
      if (po.ImSmaller) // -> outline
      {
        this.GetComponent<Renderer>().material.shader = outlineShader;
       // imOutlined = true;
      }
    }
  //  else if (!po.ImSmaller || this.transform.parent.gameObject.name == "pickup_holder")
  else
    {
      this.GetComponent<Renderer>().material.shader = normalShader;
      imOutlined = false;
    }
  }
}
