using UnityEngine;
using System.Collections;

public class slider : MonoBehaviour {
  
    RaycastHit hitwall;
    RaycastHit hitwalltwo;
    Vector3 direction = Vector3.up;
    Vector3 directionTwo = Vector3.down;
    GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player.tag);

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up*Time.deltaTime*10;
        Physics.Raycast(transform.position, direction, out hitwall, 5, (1<<8));
        Physics.Raycast(transform.position, directionTwo, out hitwalltwo, 5, (1 << 8));

        if (hitwall.collider != null)
        {
            //Destroy(Player);

        }
        if (hitwalltwo.collider != null)
        {

            //Destroy(Player);
        }



if(Player == null)
        {
            Destroy(Player);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(direction));
        Debug.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity, Color.green);
    }
}
