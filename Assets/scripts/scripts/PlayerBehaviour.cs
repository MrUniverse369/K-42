using UnityEngine;
using System.Collections;


public class PlayerBehaviour : MonoBehaviour
{
    bool ll;
    jet rr;
    public Rigidbody powerup;

    public AudioSource blueBlast;
    // Force to apply when player jumps
    public Vector2 jumpForce = new Vector2(0, 500);

    // How fast we'll let the player move in the x axis
    public float maxSpeed = 3.0f;

    // A modifier to the force applied
    public float speed = 50.0f;

    // The force to apply that we will get for the player's movement
    private float xMove;

    // Set to true when the player can jump
    private bool shouldJump;
    private bool onGround;
    private bool collidingWall;
    private float yPrevious;
    Renderer rend;
   
    // Use this for initialization


    void Start()
    {
        

        blueBlast = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
       ;
        shouldJump = false;
        xMove = 0.0f;

        onGround = false;
        yPrevious = Mathf.Floor(transform.position.y);
        collidingWall = false;
        //ll = rr.GetComponent<jet>().hh;
        
    }


    void Movement()
    {  
        //Get the player's movement (-1 for left, 1 for right, 0 for none)
        xMove = Input.GetAxis("Horizontal");

        if (collidingWall && !onGround)
        {
            xMove = 0;
        }


        if (xMove != 0)
        {
            // Setting player horizontal movement
            float xSpeed = Mathf.Abs(xMove * GetComponent<Rigidbody>().velocity.x);

            if (xSpeed < maxSpeed)
            {
                Vector3 movementForce = new Vector3(1, 0, 0);
                movementForce *= xMove * speed;

                RaycastHit hit;
                if (!GetComponent<Rigidbody>().SweepTest(movementForce, out hit, 0.05f))
                {
                    GetComponent<Rigidbody>().AddForce(movementForce);
                }
            }

            // Check speed limit
            if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > maxSpeed)
            {
                Vector2 newVelocity;

                newVelocity.x = Mathf.Sign(GetComponent<Rigidbody>().velocity.x) * maxSpeed;
                newVelocity.y = GetComponent<Rigidbody>().velocity.y;

                GetComponent<Rigidbody>().velocity = newVelocity;
            }
        }
        else
        {
            Vector2 newVelocity = GetComponent<Rigidbody>().velocity;
            newVelocity.x *= 0.9f;
            GetComponent<Rigidbody>().velocity = newVelocity;
        }
    }

    void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            shouldJump = true;
        }

        // If the player should jump
        if (shouldJump && onGround)
        {
            GetComponent<Rigidbody>().AddForce(jumpForce);
            shouldJump = false;
        }
    }

    // If we hit something and we're not grounded, it must be a wall or a ceiling. 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "platform")
        {
           
            transform.parent = collision.transform;
         

        }
        else if(collision.collider.tag != "platform")
        {
            transform.parent = null;
           
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (collision.collider.tag == "jet")
            {

                transform.parent = collision.transform;
                Debug.Log("yo");
              
                ll = false;

            }
            else if (collision.collider.tag != "jet")
            {
                transform.parent = null;
                gameObject.SetActive(true);

            }
        }
       
            if (!onGround)
        {





            collidingWall = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        collidingWall = false;
    }


    void CheckGrounded()
    {
        float distance = (GetComponent<CapsuleCollider>().height / 2 * this.transform.localScale.y) + .01f;
        Vector3 floorDirection = transform.TransformDirection(-Vector3.up);
        Vector3 origin = transform.position;

        if (!onGround)
        {
            // Check if there is something directly below us
            if (Physics.Raycast(origin, floorDirection, distance))
            {
                onGround = true;
            }
        }
        // If we are currently grounded, are we falling down or jumping?
        else if ((Mathf.Floor(transform.position.y) != yPrevious))
        {
            onGround = false;
        }

        // Our current position will be our previous next frame
        yPrevious = Mathf.Floor(transform.position.y);
    }
   


    
    void FixedUpdate()
    {
      

        if (Input.GetKey(KeyCode.K))
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        // Move the player left and right
        Movement();
        
        // Sets the camera to center on the player's position.
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity, Color.red);
    }


    // Update is called once per frame
    void Update()
    {
        powerUp();
        if(Input.GetKey(KeyCode.L))
        { Time.timeScale = 0.2f; }
        // Check if we are on the ground
        CheckGrounded();

        // Have the player jump if they press the jump button
        Jumping();
    }
   
    void powerUp()
    {
      
        float powernumber =0;
       float blueshot = 2;
        Rigidbody blueblast;
        Vector3 dir = Vector3.right;
        RaycastHit info;
        Physics.Raycast(transform.position, dir, out info, 0.2f, (1 << 11));
        if (info.collider != null)
        {
            rend.material.SetColor("_Color", Color.blue);
            powernumber = 2;
        }
        float speed= 10 * Time.deltaTime;

        if (rend.material.color == Color.blue) {
            if (Input.GetKeyUp(KeyCode.G))
            {
                blueblast = Instantiate(powerup, transform.position, transform.rotation) as Rigidbody;
                blueblast.transform.position += Vector3.right*speed; //(1 *Time.deltaTime, 0, 0, Space.World);
                Destroy(blueblast, 2f);
                blueBlast.Play();

            }
           
        }
        
    }
        
}