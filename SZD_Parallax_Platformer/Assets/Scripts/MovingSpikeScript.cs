using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikeScript : MonoBehaviour
{
    public Transform EndPoint1, EndPoint2;
    Vector3 Destination;
    public float speed;
    float timeelapsed = 0;
    bool atEndPoint = false;

    void Start()
    {
        transform.position = EndPoint1.position;
        Destination = EndPoint1.position;
    }


    void Update()
    {

        if (!atEndPoint)
            transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);
        else
            timeelapsed += 1;
    }

    private void FixedUpdate()
    {
        if (transform.position == EndPoint2.position)
        {
            Destination = EndPoint1.position;
            atEndPoint = true;
            if (timeelapsed > 1500)
            {
                timeelapsed = 0;
                atEndPoint = false;
            }
                
        }
        else if (transform.position == EndPoint1.position)
        {
            Destination = EndPoint2.position;
            atEndPoint = true;
            if (timeelapsed > 1500)
            {
                timeelapsed = 0;
                atEndPoint = false;
            }
        }

    }
}
