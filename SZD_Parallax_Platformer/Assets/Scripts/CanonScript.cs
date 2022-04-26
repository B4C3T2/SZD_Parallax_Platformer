using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public float TimeBetweenShots;
    private float MaxTimeBetweenShots;
    public GameObject Bullet;
    private GameObject player1;
    private GameObject player2;
    private GameObject target;
    private Vector2 targetLocation;
    public GameObject barrel;

    // Start is called before the first frame update
    void Start()
    {
        MaxTimeBetweenShots = TimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        target = PlayerCloser();
        targetLocation = new Vector2(target.transform.position.x, target.transform.position.y);
        barrel.transform.up = targetLocation - (Vector2)transform.position;
        if( MaxTimeBetweenShots <= 0)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
            MaxTimeBetweenShots = TimeBetweenShots;
        }
        else
        {
            MaxTimeBetweenShots -= Time.deltaTime;
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
}
