using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDeadlyWall : MonoBehaviour
{
    public Transform StartPosition, EndPosition;
    public float speed;
    Vector3 Destination;

    void Start()
    {
        Destination = StartPosition.position;
    }
    void Update()
    {
        if (transform.position == EndPosition.position)
            Destination = StartPosition.position;
        else if (transform.position == StartPosition.position)
            Destination = EndPosition.position;
        transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);
    }
}
