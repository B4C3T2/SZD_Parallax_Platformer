using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Transform EndPoint1, EndPoint2;
    Vector3 Destination;
    public float speed;

    void Start()
    {
        transform.position = EndPoint1.position;
        Destination = EndPoint1.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);
        transform.Rotate(0, 0, -2);
    }

    private void FixedUpdate()
    {
        if (transform.position == EndPoint2.position)
            Destination = EndPoint1.position;
        else if (transform.position == EndPoint1.position)
            Destination = EndPoint2.position;
    }
}
