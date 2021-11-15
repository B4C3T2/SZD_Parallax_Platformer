using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform StartPosition, EndPosition;
    Vector3 Destination;
    
    void Start()
    {
        //transform.position = StartPosition.position;
        Destination = StartPosition.position;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination, Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (transform.position == EndPosition.position)
            Destination = StartPosition.position;
        else if (transform.position == StartPosition.position)
            Destination = EndPosition.position; 
    }
}
