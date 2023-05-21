using UnityEngine;
using System.Collections;
public class OrbBehaviour : MonoBehaviour 
{

    AudioSource coinSound;
    void Start()
    {
       
        coinSound = GetComponent<AudioSource>();
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            coinSound.Play();
            //Debug.Log("ding");
            GameController._instance.CollectedOrb();
            Destroy(this.gameObject, 0.5f);
           
        }   
    }
   
   
  


    void Update()
    {
       
     /*   RaycastHit info;
        RaycastHit infow;
        RaycastHit infoe;
        RaycastHit infor;
        Vector3 dirq = Vector3.left;
        Vector3 dirw = Vector3.right;
        Vector3 dire = Vector3.up;
        Vector3 dirr = Vector3.down;
        Physics.Raycast(transform.position, dirq, out info, 1f, (1 << 13));
        Physics.Raycast(transform.position, dirw, out infow, 1f, (1 << 13));
        Physics.Raycast(transform.position, dire, out infor, 1f, (1 << 13));
        Physics.Raycast(transform.position, dirr, out infoe, 1f, (1 << 13));

        if (info.collider != null)
        {
           coinSound.Play();
           // Debug.Log("we made a sound");
        }

        if (infow.collider != null)
        { coinSound.Play(); }

        if (infoe.collider != null)
        { coinSound.Play(); }

        if (infor.collider != null)
        { coinSound.Play(); }
    */
}

 
       

}
