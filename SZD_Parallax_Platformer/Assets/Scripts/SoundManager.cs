using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicTune"))
        {
            PlayerPrefs.SetFloat("MusicTune", 1f);
            Load();
        }
        else
            Load();       
    }
    public void VolumeChanging()
    {
        AudioListener.volume = volumeslider.value;
        Save();
    }
    private void Load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("MusicTune");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("MusicTune", volumeslider.value);
    }


}
