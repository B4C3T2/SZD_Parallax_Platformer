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
        float player1distance = Vector3.Distance(player1.transform.position, transform.position);
        float player2distance = Vector3.Distance(player2.transform.position, transform.position);

        return (player1distance < player2distance) ? player1 : player2;
    }
}
