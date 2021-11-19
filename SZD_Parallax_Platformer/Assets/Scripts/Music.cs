using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music MusicAllowEveryScene;

    private void Awake()
    {
        if (MusicAllowEveryScene != null && MusicAllowEveryScene != this)
        {
            Destroy(this.gameObject);
            return;
        }
        MusicAllowEveryScene = this;
        DontDestroyOnLoad(this);


    }

}
