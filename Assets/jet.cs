using UnityEngine;
using System.Collections;

public class jet : MonoBehaviour
{
    public bool hh;
    GameObject gg;
    Rigidbody jetrb;
    Vector3 velocity;
    Vector3 finalvelocity;
    public float drag;
    public float speed;
    GameObject jetrocket;
    GameObject pilot;

    public Rigidbody redcore;
    GameObject JetGun;

    // Use this for initialization
    void Start()
    {

        hh = true;
        gg = GameObject.FindGameObjectWithTag("Player");
        pilot = GameObject.FindGameObjectWithTag("pilot");
        jetrb = GetComponent<Rigidbody>();
        velocity = Vector3.right * speed;
        jetrocket = GameObject.FindGameObjectWithTag("jetrocket");
        pilot.SetActive(false);

        JetGun = GameObject.FindGameObjectWithTag("jetgun");

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {


        if (collision.collider.tag == "bullet")
        {
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);

        }
    }

    void Update()
    {
        Shoot();
     
        finalvelocity = velocity / drag;

     
        if (Input.GetKey(KeyCode.P))
        {
            hh = false;
            pilot.SetActive(true);
            gg.SetActive(false);
            gg.transform.parent = transform;

          
        }


        if (hh == false)
        {
            if (Input.GetKey(KeyCode.O))

            {
                hh = true;
                pilot.SetActive(false);
                gg.SetActive(true);
            }


            if (Input.GetKey(KeyCode.D))
            {
                jetrocket.transform.Rotate(0, 0, 500 * Time.deltaTime);
                jetrb.AddForce(speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                jetrb.AddForce(-speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                jetrb.AddForce(0, speed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * Time.deltaTime;
            }
        }

    }

    void Shoot()
    {
        Rigidbody JetBullet;
        float sspeed = Time.deltaTime;





        if (Input.GetKey(KeyCode.G) || Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("pew pew");
            JetBullet = Instantiate(redcore, JetGun.transform.position, JetGun.transform.rotation) as Rigidbody;
            // JetBullet.transform.position += Vector3.right * sspeed;
            JetBullet.transform.Translate(Vector3.right * sspeed);



        }

    }


}


    


