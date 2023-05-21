using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    Vector3 direction;
    Vector3 directionTwo;
    RaycastHit hitwall;
    RaycastHit hitwallTwo;
    bool go;
    // Use this for initialization
    void Start () {
        direction = Vector3.right;
        directionTwo = Vector3.left;
        go = true;
	}
	
	// Update is called once per frame
	void Update () {

        
        Physics.Raycast(transform.position, direction, out hitwall, 2, (1 << 9) | (1 << 10));
        Physics.Raycast(transform.position, directionTwo, out hitwallTwo, 2, (1 << 9) | (1 << 10));

        if (hitwall.collider != null && hitwallTwo.collider == null)

        {
            go = false;

        }
        if (hitwall.collider == null && hitwallTwo.collider != null)

        {
            go = true;

        }
        switch (go)
        {
            case true:
                transform.Translate(Vector3.right* Time.deltaTime);
                break;
            case false:
                transform.Translate(Vector3.left * Time.deltaTime);
                break;
            default:
                break;
        }
        //Debug.Log(go);
      //  Debug.Log(hitwall.collider);
      //  Debug.Log(hitwallTwo.collider);
       
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(direction));
        Debug.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity, Color.green);
    }
}
