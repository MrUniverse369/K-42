using UnityEngine;
using System.Collections;

public class MainMenue : MonoBehaviour {
   
  public  GUISkin mainskin;
    float windowwidth = 256;
    float windowheight = 100;
    float windowX;
    float windowY;
    GameObject player;
public    AudioSource levelMusic;
    // Use this for initialization
    void Start () {
        levelMusic = GetComponent<AudioSource>();
        levelMusic.Play();
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Update() { transform.Rotate(0,0,20*Time.deltaTime);
      
    }
    void OnGUI()
    {
        GUI.skin = mainskin;
        windowX = (Screen.width -windowwidth)/ 2;
        windowY = (Screen.height - windowheight) / 2;
        GUILayout.BeginArea(new Rect(windowX, windowY, windowwidth,windowheight));
        if (GUILayout.Button( "start game"))
            Application.LoadLevel("training level");
        if (GUILayout.Button( "Quit"))
            Application.Quit();
        GUILayout.EndArea();
        transform.Rotate(0, 0, 200 * Time.deltaTime);
    }

   
}
