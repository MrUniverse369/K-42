using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
   public Rigidbody bulleto;
    float distance;
    Animator animator;
    Vector2 velocity;
    GameObject control;
    RaycastHit hitwall;
    RaycastHit hitwalltwo;
  public  GameObject player;
    public Rigidbody bulletl;
    float shotime = 0;
    float cooldown = 4.0f;
    Vector3 direction = Vector3.left;
    Vector3 directionTwo = Vector3.right;
    Vector3 kpdirection = Vector3.left;
    Vector3 kpdirectionright = Vector3.right;
    RaycastHit hitplayer;
    RaycastHit hitplayerright;
    GameObject enemy;


    // Use this for initialization

    void Start() {
      StartCoroutine(waitforasecond());
        bulletl = GetComponent<Enemy>().bulletl;
        animator = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("bullet");
    }

    //Update is called once per frame
    void FixedUpdate() {

        waitforasecond();


        if (hitplayer.collider || hitplayerright.collider != null)
        { animator.SetBool("Playersensed", true); }
        else
        {
            animator.SetBool("Playersensed", false);
        }

        transform.Translate(5 * Time.deltaTime, 0, 0);
        Physics.Raycast(transform.position, direction, out hitwall, 1, (1 << 9) | (1 << 10)| (1 << 15));
        Physics.Raycast(transform.position, directionTwo, out hitwalltwo, 1, (1 << 9) | (1 << 10)| (1 << 15));
        
        if (hitwall.collider != null)
        {   transform.Rotate(0, 0, 180);
            transform.position += Vector3.right * Time.deltaTime;
            
        }
        if (hitwalltwo.collider != null)
        {
           transform.Rotate(0, 0, 180);
           transform.position += Vector3.left * Time.deltaTime;
           
        }
    
        
    }


    void KillPlayer()
    {
        
        Physics.Raycast(transform.position, kpdirection, out hitplayer, 5, (1 << 8));
        Physics.Raycast(transform.position, kpdirectionright, out hitplayerright, 5, (1 << 8));

        if (hitplayer.collider != null)
        {
            
            bulleto = Instantiate(bulletl, transform.position, transform.rotation) as Rigidbody;

            transform.Translate(-38.2f*Time.deltaTime,0,0);
           
       

        }
            if (hitplayerright.collider != false)
            {
                bulleto = Instantiate(bulletl, transform.position, transform.rotation) as Rigidbody;
            bulleto.transform.Translate(38.2f*Time.deltaTime,0,0);
        }
       
    }

        IEnumerator waitforasecond()
    {
        while (shotime < cooldown)
        {

            KillPlayer();

            yield return new WaitForSeconds(0.25f);
           // Debug.Log("you waited 3seocnds");
            shotime += Time.deltaTime;
            //print("working");
        }
        shotime = 0.0f;
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(direction));
        Debug.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity, Color.green);
    }
}
