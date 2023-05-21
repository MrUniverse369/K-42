using UnityEngine;
using System.Collections;


public class LevelOneGui : MonoBehaviour {

 public   GUISkin leveloneskin;
    float windowwidth = 256;
    float windowheight = 100;
    float windowX;
    float windowY;
    float paused;
    // Use this for initialization
 
    void Start () {

        paused = 0f;

    }


    // Update is called once per frame
    void Paused()
    {
        windowX = (Screen.width - windowwidth) / 2;
        windowY = (Screen.height - windowheight) / 2;

        GUILayout.BeginArea(new Rect(windowX, windowY, windowwidth, windowheight));
        if (GUILayout.Button("resume"))
        {
            paused = 2;

        }
        else if (GUILayout.Button("restart"))
        {

            Application.LoadLevel(Application.loadedLevelName);
            paused = 2;
        }
        else if (GUILayout.Button("Main menue"))
        {
            Application.LoadLevel("level 1");
            paused = 2;
        }
        GUILayout.Label("Arrows to move space to jump g to shoot ");
        
  
    
        

        GUILayout.EndArea();

    }
    void OnGUI () {
        GUI.skin = leveloneskin;
        
        if (Input.GetKey(KeyCode.Escape))
        {
            paused = 1f;

        }

        if (paused == 1f)
        {
            Time.timeScale = 0.0f;
            Paused();
        }

        else if (paused == 2f )
        {
            Time.timeScale = 1.0f;
        }
       /* if(Input.GetKey(KeyCode.H))
        {
            paused = 3f;
            Debug.Log(paused);
            Time.timeScale = 0.2f;
        }*/
    }
     void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            Application.LoadLevel("level3");

        }
        if (Input.GetKey(KeyCode.N))
        {
            Application.LoadLevel("level2");
        }
    }
}
