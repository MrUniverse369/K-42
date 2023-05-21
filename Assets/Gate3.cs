using UnityEngine;
using System.Collections;

public class Gate3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            Destroy(this.gameObject, 6f);
            Application.LoadLevel("leve4");

        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
