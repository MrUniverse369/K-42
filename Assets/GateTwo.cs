using UnityEngine;
using System.Collections;

public class GateTwo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          
           
            Destroy(this.gameObject, 6f);
            Application.LoadLevel("level3");
           
        }
    }
    // Update is called once per frame
    void Update () {
        transform.position += Vector3.zero;
	
	}
}
