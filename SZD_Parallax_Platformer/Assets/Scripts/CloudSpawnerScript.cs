using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnRate;

    [SerializeField]
    GameObject endpoint;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        Invoke("MakeSpawn", spawnRate);
    }


    void Spawn(Vector3 startPosition)
    {
        GameObject cloud = Instantiate(clouds[UnityEngine.Random.Range(0, clouds.Length)]);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        float scale = UnityEngine.Random.Range(0.5f, 0.8f);
        float startPointY = UnityEngine.Random.Range(startPosition.y - 1f, startPosition.y + 1f);
        cloud.transform.localScale = new Vector2(scale, scale);
        cloud.transform.position = new Vector3(startPosition.x, startPointY, startPosition.z);

        cloud.GetComponent<CloudMovement>().StartFloating(speed, endpoint.transform.position.x);
    }

    void MakeSpawn()
    {
        Spawn(startPosition);
        Invoke("MakeSpawn", spawnRate);
    }
}
