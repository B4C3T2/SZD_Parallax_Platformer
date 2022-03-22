using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscrippt : MonoBehaviour
{
    private GameObject player1, player2;
    private GameObject target;
    private Vector2 targetLocation;
    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        target = PlayerCloser();
        targetLocation = new Vector2(target.transform.position.x, target.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetLocation, 4 * Time.deltaTime);
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
        float player1distance = Vector3.Distance(player1.transform.position, transform.position);
        float player2distance = Vector3.Distance(player2.transform.position, transform.position);

        return (player1distance < player2distance) ? player1 : player2;
    }

    private bool HitGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }
}
