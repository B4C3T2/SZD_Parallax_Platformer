using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedskin1;
    public GameObject Player1;
    private Sprite playersprite1;


    public GameObject selectedskin2;
    public GameObject Player2;
    private Sprite playersprite2;
    void Start()
    {
        playersprite1 = selectedskin1.GetComponent<SpriteRenderer>().sprite;
        playersprite2 = selectedskin2.GetComponent<SpriteRenderer>().sprite;

        Player1.GetComponent<SpriteRenderer>().sprite = playersprite1;
        Player2.GetComponent<SpriteRenderer>().sprite = playersprite2;
    }

}
