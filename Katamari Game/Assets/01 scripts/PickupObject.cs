using UnityEngine;
using System.Collections;

//script to check if ball is bigger than the pickup
//Mesh colliders need to be CONVEX if you want to use triggers
public class PickupObject : MonoBehaviour
{
  private GameObject playerObject;
  private GameObject pickup;
  private float volumePickup;
  private bool isOutlined = false;
  private bool imSmaller = false;

  private float ballVolume;
  private SphereCollider spherecol;

  void Start()
  {
    playerObject = GameObject.FindGameObjectWithTag("Player");
    spherecol = playerObject.GetComponent<SphereCollider>();
    pickup = this.gameObject;
    //pickup.gameObject.tag = "PickUp"; //put this tag onto the object the script is hanging onto -> do this manualy
    // volumePickup = pickup.transform.localScale.x * pickup.transform.localScale.y * pickup.transform.localScale.z;

    volumePickup = VolumeOfMesh(pickup.GetComponent<MeshFilter>().sharedMesh);

    if (pickup.name == "Duck (11)")
      Debug.Log(pickup.name + " " + volumePickup);
  }

  void Update()
  {
    //volume sphere:  4/3 * pi * r^3
    //divided by two since I only have the diametre and I need r
    //so when the pickups are smaller than the ball
    //if ((((4 / 3) * Mathf.PI * Mathf.Pow(playerObject.transform.localScale.y / 2f, 3))) > volumePickup)
    ballVolume = ((4 / 3) * Mathf.PI * Mathf.Pow(playerObject.transform.localScale.z / 2f, 3f));
    if (Input.GetKeyDown(KeyCode.P))
    { Debug.Log("ball  " + ballVolume); }

    if (ballVolume > volumePickup)
    {

      imSmaller = true;
      if (pickup.gameObject.GetComponent<MeshCollider>() != null) //when it has a mesh collider
      {
        foreach (MeshCollider c in GetComponents<MeshCollider>())
        {
          c.convex = true;
          c.enabled = true; // turn the mesh collider on
          c.isTrigger = true; //turn on the trigger for the mesh
        }

        if (pickup.gameObject.GetComponent<BoxCollider>() != null)//if it has other colliders than the mesh, turn all other colliders off
        {
          foreach (Collider c in GetComponents<BoxCollider>())
          {
            c.enabled = false;
          }
        }

        if (pickup.gameObject.GetComponent<SphereCollider>() != null)//if it has other colliders than the mesh, turn all other colliders off
        {
          foreach (Collider c in GetComponents<SphereCollider>())
          {
            c.enabled = false;
          }
        }
      }
      else //when it has no meshCollider, but it does have other colliders
      {
        pickup.gameObject.GetComponent<Collider>().isTrigger = true;
      }
    }
  }

  public bool ImSmaller
  {
    get { return imSmaller; }
  }

  public float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
  {
    float v321 = p3.x * p2.y * p1.z;
    float v231 = p2.x * p3.y * p1.z;
    float v312 = p3.x * p1.y * p2.z;
    float v132 = p1.x * p3.y * p2.z;
    float v213 = p2.x * p1.y * p3.z;
    float v123 = p1.x * p2.y * p3.z;
    return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
  }

  public float VolumeOfMesh(Mesh mesh)
  {
    float volume = 0;
    Vector3[] vertices = mesh.vertices;
    int[] triangles = mesh.triangles;
    for (int i = 0; i < mesh.triangles.Length; i += 3)
    {
      Vector3 p1 = vertices[triangles[i + 0]];
      Vector3 p2 = vertices[triangles[i + 1]];
      Vector3 p3 = vertices[triangles[i + 2]];
      volume += SignedVolumeOfTriangle(p1, p2, p3);
    }
    return volume *= this.gameObject.transform.localScale.x * this.gameObject.transform.localScale.y * this.gameObject.transform.localScale.z;
  }


}
