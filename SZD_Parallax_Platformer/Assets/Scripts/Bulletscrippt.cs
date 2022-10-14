using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscrippt : MonoBehaviour
{
    private GameObject player1, player2;
    private GameObject target;
    private Vector3 targetLocation;
    public List<LayerMask> groundLayers;
    private LayerMask currentGroundLayer;
    private float distance;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        target = PlayerCloser();
        targetLocation = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        if(targetLocation.z == 0)
        {
            Physics2D.IgnoreLayerCollision(16, 10, true);
            Physics2D.IgnoreLayerCollision(16, 12, true);
            currentGroundLayer = groundLayers[0];
        }                                  
        else                               
        {                                  
            Physics2D.IgnoreLayerCollision(16, 3, true);
            Physics2D.IgnoreLayerCollision(16, 7, true);
            currentGroundLayer = groundLayers[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetLocation, 4 * Time.deltaTime);
        if ((transform.position.x == targetLocation.x && transform.position.y == targetLocation.y) ||
            HitGround())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            Destroy(gameObject);
        }
    }

    private GameObject PlayerCloser()
    {
        float player1distance = CalculateDistance(player1.transform, transform);
        float player2distance = CalculateDistance(player2.transform, transform);

        return (player1distance < player2distance) ? player1 : player2;
    }

    private float CalculateDistance(Transform p1, Transform p2)
    {
        return (float)Math.Sqrt(
                        Math.Pow(p2.position.x - p1.position.x, 2) +
                        Math.Pow(p2.position.y - p1.position.y, 2));
    }

    private bool HitGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(transform.position, 0.1f, currentGroundLayer);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }
}
