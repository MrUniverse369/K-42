using UnityEngine;
using System.Collections;

public class destroyblueblast : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right*10*Time.deltaTime );
        Destroy(gameObject, 1.5f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}