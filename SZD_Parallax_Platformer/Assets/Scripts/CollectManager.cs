using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectManager : MonoBehaviour
{
    
    private bool isCollected = false;
    public int zero = 0;
    List<float> positionX;
    List<float> positionY;
    private void Start()
    {
        positionX = new List<float>();
        positionX.Add(-2f);
        positionX.Add(9f);
        positionX.Add(4f);
        positionX.Add(-9f);
        positionX.Add(-10f);

        positionY = new List<float>();
        positionY.Add(-4f);
        positionY.Add(-4f);
        positionY.Add(0f);
        positionY.Add(1f);
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
        float rndX = positionX[(int)Random.Range(0,5)];
        float rndY = positionY[(int)Random.Range(0, 4)];
        gameObject.transform.position -= new Vector3(rndX, rndY, 7f);
        isCollected = false;
    }



}
