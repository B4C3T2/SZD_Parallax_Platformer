using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public float TimeBetweenShots;
    private float MaxTimeBetweenShots;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        MaxTimeBetweenShots = TimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if( MaxTimeBetweenShots <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            MaxTimeBetweenShots = TimeBetweenShots;
        }
        else
        {
            MaxTimeBetweenShots -= Time.deltaTime;
        }
    }
}
