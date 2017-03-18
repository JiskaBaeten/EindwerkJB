using UnityEngine;
using System.Collections;

//script to check if ball is bigger than the pickup
//Mesh colliders need to be CONVEX if you want to use triggers
public class PickupObject : MonoBehaviour
{
  public GameObject playerObject;
  private GameObject pickup;
  private float volumePickup;
  private bool isOutlined = false;
  private bool imSmaller = false;

  void Start()
  {
    playerObject = GameObject.FindGameObjectWithTag("Player");
    pickup = this.gameObject;
    //pickup.gameObject.tag = "PickUp"; //put this tag onto the object the script is hanging onto -> do this manual
    volumePickup = pickup.transform.localScale.x * pickup.transform.localScale.y * pickup.transform.localScale.z;
  }

  void Update()
  {
    //volume sphere: r^3 * pi * 4/3 is bigger than the pickup
    //divided by two since I only have the diametre
    if ((((playerObject.transform.localScale.x / 2f) * (playerObject.transform.localScale.x / 2f) * (playerObject.transform.localScale.x / 2f)) * 3.14f * (4 / 3)) > (volumePickup))
    {
      imSmaller = true;
      if (pickup.gameObject.GetComponent<MeshCollider>() != null) //when it has a mesh collider
      { 
        pickup.gameObject.GetComponent<MeshCollider>().isTrigger = true; //turn on the trigger for the mesh

        if (pickup.gameObject.GetComponent<BoxCollider>() != null)//if it has other colliders than the mesh, turn all other colliders off
        { 
          foreach (Collider c in GetComponents<BoxCollider>())
          {
            c.enabled = false;
          }
        }
      }
      else //when it has no meshCollider
      {
        pickup.gameObject.GetComponent<Collider>().isTrigger = true;
      }
    }
  }

  public bool ImSmaller
  {
    get { return imSmaller; }
  }
}
