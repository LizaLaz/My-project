using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valume : MonoBehaviour
{
    public GameObject AudioMan;
    private AudioSource audioSrc;
    public static float musicVolume;
    public Slider slider;
    public GameObject[] objs1;

    void Awake()
    {
       
        if(!PlayerPrefs.HasKey("MusicVol"))
        {
            musicVolume = 1f;//громкость по умолчанию
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVol");//сохранение громкости
            slider.value = PlayerPrefs.GetFloat("MusicVol");//меняется значение слайдера на сохраненную громкость
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;//установление громкости при изменении слайдера
    }
    public void SetVolume(float vol)
    {
      musicVolume = vol;
      PlayerPrefs.SetFloat("MusicVol", vol);//сохранение громкости
    }
}
