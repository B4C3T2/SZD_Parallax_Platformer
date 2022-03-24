using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Hungarian:
                break;
            case SystemLanguage.English:
                break;
            case SystemLanguage.German:
                break;
        }

    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
