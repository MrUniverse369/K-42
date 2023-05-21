using UnityEngine;
using System.Collections;

public class pillarscript : MonoBehaviour {
    bool bb;
    int dd;
    Vector3 direction;
    RaycastHit wallout;
    RaycastHit walloutTwo;
    Rigidbody platformrb;
    // Use this for initialization
    void Start () {
        direction = Vector3.up;
        bb = false;
        dd = 0;
        platformrb = GetComponent<Rigidbody>();
    }


    
    // Update is called once per frame
   void Update()
    {
        

         
                Physics.Raycast(transform.position, Vector3.up, out wallout, 1, (1 << 9)|(1<<10) | (1 << 15));
                Physics.Raycast(transform.position, Vector3.down, out walloutTwo, 2, (1 << 9)|(1<<10)| (1 << 15));



                if (wallout.collider == null && walloutTwo.collider != null)
                { dd = 1; }
                if (walloutTwo.collider == null && wallout.collider != null)
                {
                    dd = 2;
                }
                else if (walloutTwo.collider != null && dd == 2)
                {
                    dd = 1;
                }

                switch (dd)
                { case 1: 
                        platformrb.AddForce(Vector3.up *500 *Time.deltaTime);
                        break;
                    case 2:


                        platformrb.AddForce(Vector3.down);
                        break;

                    case 3:
                        transform.position += Vector3.down;
                        break;
                    default:
                        platformrb.AddForce(Vector3.up);
                        break;
                }



        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(direction));
        Debug.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity, Color.green);
    }
}
