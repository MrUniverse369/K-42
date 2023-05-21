using UnityEngine;
using System.Collections;

public class destroyenemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "powerup")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "jetbullet")
        {
            Destroy(gameObject);
        }
    }
 
    }
