using UnityEngine;
using System.Collections;

public class soulscript : MonoBehaviour {
    AudioSource youwin;
    AudioSource pauseplay;
    GameObject g;
    GameObject h;
    Collider s;
    float jj;
    // Use this for initialization
    void Start () {
        StartCoroutine(waitforasecond());
        youwin = GetComponent<AudioSource>();
        g = GameObject.FindGameObjectWithTag("GameController");
        h = GameObject.FindGameObjectWithTag("Player");
      //  pauseplay = g.GetComponent<AudioSource>();
        jj = 10;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // pauseplay.Pause();
            youwin.Play();
            Debug.Log("we made it");
            Destroy(this.gameObject, 6f);
             Application.LoadLevel("level2");
            waitforasecond();}
    }


    IEnumerator waitforasecond()
    {
     
            yield return new WaitForSeconds(1f);
        
           
          //  Debug.Log("we did it baby");
      
        }

    // Update is called once per frame
    void Update () {
        
    
	}
}
