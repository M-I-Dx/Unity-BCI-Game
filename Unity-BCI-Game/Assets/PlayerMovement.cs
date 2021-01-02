using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initialpos;
    public Vector3 Center;
    public Vector3 Lower;
    public Vector3 Left;
    public Vector3 Right;
    int c=0, d=0, r=0, l=0; 
    int active=0;
    void Start()
    {
        initialpos = GameObject.FindGameObjectsWithTag("Goal")[0].transform.position; 
        transform.position = Vector3.MoveTowards(transform.position, initialpos, 500f*Time.deltaTime);
        // Possible locations to move
        Center = GameObject.FindGameObjectsWithTag("Goal")[0].transform.position;
        Lower = GameObject.FindGameObjectsWithTag("Goal")[1].transform.position;
        Left = GameObject.FindGameObjectsWithTag("Goal")[2].transform.position;
        Right = GameObject.FindGameObjectsWithTag("Goal")[3].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (c == 1 & (transform.position != Center))
        {
            transform.position = Vector3.MoveTowards(transform.position, Center, 10f*Time.deltaTime);
        }
        else if (c == 1 & (transform.position == Center))
        {
            c = 0;
            active = 0;
        }

        if (d == 1 & (transform.position != Lower))
        {
            transform.position = Vector3.MoveTowards(transform.position, Lower, 10f*Time.deltaTime);
        }
        else if (d == 1 & (transform.position == Lower))
        {
            d = 0;
            active = 0;
        }

        if (l == 1 & (transform.position != Left))
        {
            transform.position = Vector3.MoveTowards(transform.position, Left, 10f*Time.deltaTime);
        }
        else if (l == 1 & (transform.position == Left))
        {
            l = 0;
            active = 0;
        }

        if (r == 1 & (transform.position != Right))
        {
            transform.position = Vector3.MoveTowards(transform.position, Right, 10f*Time.deltaTime);
        }
        else if (r == 1 & (transform.position == Right))
        {
            r = 0;
            active = 0;
        }


        if (active == 0)
        {
            if (Input.GetKey("w") & (transform.position != Center))
            {
                c = 1;
                active = 1;
            }
            else if (Input.GetKey("s") & (transform.position != Lower))
            {
                d = 1;
                active = 1;
            }
            else if (Input.GetKey("a") & (transform.position != Left))
            {
                l = 1;
                active = 1;
            }
            else if (Input.GetKey("d") & (transform.position != Right))
            {
                r = 1;
                active = 1;
            }
        }
    }
}
