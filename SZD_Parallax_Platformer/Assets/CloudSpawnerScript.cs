using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endpoint;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        Invoke("AttemptSpawn", spawnInterval);

    }


    void SpawnCloud()
    {
        GameObject cloud = Instantiate(clouds[UnityEngine.Random.Range(0, clouds.Length)]);

        startPos.y = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 1f);
        cloud.transform.position = startPos;

        float scale = UnityEngine.Random.Range(0.5f, 0.8f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<CloudMovement>().StartFloating(speed, endpoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        //checking if needed
        SpawnCloud();

        Invoke("AttemptSpawn", spawnInterval);
    }
}
