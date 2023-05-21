using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour
{

    public Vector3[] path;
    int indexx;
    int index;
    Vector3 endPos;
    int reachdist;
    Vector3 velocity;
    float speed;
    // Use this for initialization

    public Vector3 Getpoint(int index)
    {
        return path[indexx];
    }


    void Start()
    {
        index = 0;
        reachdist = 1;
      //  velocity = path[indexx] - transform.position;
        speed = 1 * Time.deltaTime;
      
    }

    // Update is called once per frame
    void Update()
    {
        velocity = path[indexx] - transform.position;
        

        if (indexx < path.Length)
        {

            //    velocity = path[indexx] - transform.position;
            transform.position += velocity * speed;


        }

       // Debug.Log(path[indexx]);
        //Debug.Log(velocity.magnitude);
        if (velocity.magnitude <= reachdist)
        {
            ++indexx;
        }
        if (indexx >= path.Length)
        {
            indexx = 0;
        }
    }
}