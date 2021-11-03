using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float speed;
    private float endPosX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartFloating(float speed, float endPosX)
    {
        this.speed = speed;
        this.endPosX = endPosX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < endPosX)
        {
            Destroy(gameObject);
        }
    }
}
