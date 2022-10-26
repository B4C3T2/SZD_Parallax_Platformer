using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectManager : MonoBehaviour
{
    
    private bool isCollected = false;
    public int zero = 0;
    List<Vector3> capeSpawnPoints;
    private void Start()
    {
        capeSpawnPoints = new List<Vector3>();
        capeSpawnPoints.Add(new Vector3(2f,4f, 7f));
        capeSpawnPoints.Add(new Vector3(-9f, 4f, 7f));
        capeSpawnPoints.Add(new Vector3(-4f, 0f, 7f));
        capeSpawnPoints.Add(new Vector3(-6f, -1f, 7f));
        capeSpawnPoints.Add(new Vector3(10f, -4f, 7f));
        capeSpawnPoints.Add(new Vector3(6f, 2f, 7f));
    }
    public bool Collect()
    {
        if (isCollected)
            return false;      
        isCollected = true;
        gameObject.transform.position += new Vector3(0f, 0f, 7f);
        return true;       
    }
    public void ReplaceKey()
    {
        StartCoroutine(WaitForKey());      
    }
    private IEnumerator WaitForKey()
    {  
        yield return new WaitForSeconds(5f);
        gameObject.transform.position -= new Vector3(0f, 0f, 7f);
        isCollected = false;
    }
    public void ReplaceCape()
    {
        StartCoroutine(WaitForCape());
    }
    private IEnumerator WaitForCape()
    {      
        yield return new WaitForSeconds(10f);
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        gameObject.transform.position -= capeSpawnPoints[(int)Random.Range(0, 6)];
        isCollected = false;
    }



}
