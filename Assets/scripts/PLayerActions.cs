using UnityEngine;
using System.Collections;

public class PLayerActions : MonoBehaviour {

    Rigidbody rig;
    bool rotatebool;
    Vector3 velocity;
    public float speed;
    public float gravity;
    GameObject gh;
    Quaternion rotation;
    public Rigidbody powerup;
    public AudioSource blueBlast;
    GameObject Core;
    GameObject torso;
    GameObject forcefield;
  public  bool powerOn;
    GameObject powerupref;
    bool isForceFieldActive;



    // Use this for initialization
    void Start() {

        velocity = Vector3.left * Time.deltaTime;
        gh = GameObject.FindGameObjectWithTag("Player");
        rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        rig = GetComponent<Rigidbody>();
        Core = GameObject.FindGameObjectWithTag("core");
        torso = GameObject.FindGameObjectWithTag("torso");
        forcefield = GameObject.FindGameObjectWithTag("forcefield");
        forcefield.SetActive(false);
        powerOn = false;
        isForceFieldActive = false;
        powerupref = GameObject.FindGameObjectWithTag("powerup");
    }

    // Update is called once per frame
    void Update() {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        Movemant();
        Jump();
        powerUp();
        ForceField();
        ObstacleDeath(); 
         Debug.Log(isForceFieldActive);
      
    }




    void Jump()
    {
        RaycastHit feedback;
        Vector3 jumpforce = Vector3.up * 25;
        Vector3 rayDirection = Vector3.down;
        Vector3 rayOrigin = transform.position;
        float rayDistance = 0.5f;
        bool jump = false;


        Physics.Raycast(rayOrigin, rayDirection, out feedback, rayDistance);
        if (feedback.collider == null)
        {
            jump = true;


        }
        else { jump = false; }
        if (Input.GetKeyDown(KeyCode.Space) && jump == false || Input.GetKeyDown(KeyCode.W) && jump == false)
        {
            rig.AddForce(jumpforce * 20);
        }
        if (Input.GetKey(KeyCode.Space) && jump == false && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W) && jump == false && Input.GetKey(KeyCode.A))
        {
            //  rig.AddForce(jumpforce*2);
        }
    }
    void Movemant()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        }
    }
    void ForceField()
    {
        if (forcefield != null) { 

        if (Input.GetKey(KeyCode.H))
        {
               

            forcefield.SetActive(true);
                isForceFieldActive = true;

            }
           

            

    }
        if (forcefield == null)
        {
            isForceFieldActive = false;
        }
    }
    void powerUp()
    {
        Renderer rend;
        blueBlast = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        Rigidbody blueblast;
        Vector3 dir = Vector3.right;
       
        if (this.gameObject != null)
        {
            if (powerOn == true)
            {
                rend.material.SetColor("_Color", Color.blue);
                Destroy(powerupref, 0.3f);
            }
           
            float sspeed = 10 * Time.deltaTime;

            if (rend.material.color == Color.blue)
            {
                if (Input.GetKey(KeyCode.G) || Input.GetKeyDown(KeyCode.K))
                {
                    Debug.Log("pew pew");
                    blueblast = Instantiate(powerup, Core.transform.position, transform.rotation) as Rigidbody;
                    blueblast.transform.position += Vector3.right * sspeed;
                   // Destroy(blueblast, 1f);
                    blueBlast.Play();

                }

            }

        }
    }
    void ObstacleDeath()
    {
      


}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "slider" && isForceFieldActive == true)
        {
            Destroy(forcefield);
        }
            if (collision.collider.tag == "slider" && isForceFieldActive == false)
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "bullet" && isForceFieldActive == false)
        {
            Destroy(this.gameObject);
            Debug.Log("playerisdown");
        }
            if (collision.collider.tag =="powerup")
        {
            powerOn = true;
        }

        if (collision.collider.tag == "platform")
        {

            transform.parent = collision.transform;


        }
        else if (collision.collider.tag != "platform")
        {
            transform.parent = null;

        }
    }
    }
