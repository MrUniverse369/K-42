using UnityEngine;
using System.Collections;

public class destroylayer : MonoBehaviour
{
    int lives = 0;
    int currentlives = 0;
    int damege = 10;
    float death;
    float forceFieldbar;
    float forceFieldlife;
    GameObject forcefield;
    GameObject player;
    bool alive;
    GameObject Core;
    // Use this for initialization
    void Start()
    {

        forceFieldlife = 500;
        forcefield = GameObject.FindGameObjectWithTag("forcefield");
        player = GameObject.FindGameObjectWithTag("Player");
        forceFieldbar = 30;
        alive = false;
       Core = GameObject.FindGameObjectWithTag("core");
    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.collider.tag == "player")

        {

            Destroy(player);
          
        }
            if (collision.collider.tag == "forcefield")
            {    Destroy(forcefield);
                Debug.Log("shields arew down");
            }

        }







    void Sliderkill()
    {
        RaycastHit hitinfo;
        Physics.Raycast(transform.position, Vector3.down, out hitinfo, 0.5f, (1 << 14));

        if (hitinfo.collider != null)
        {
            Destroy(player);
        }
    }

    // Update is called once per frame



    void Update()
    {
        //Sliderkill();

    }
    }


