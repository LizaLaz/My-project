using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ResolutionSetting : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    public Toggle toggle;
    Resolution[] res;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            if(PlayerPrefs.GetInt("FullScreen")== 0)
            {
                Screen.fullScreen = false;
                toggle.isOn = !Screen.fullScreen;
            }
            else
            {
                Screen.fullScreen = true;
                toggle.isOn = !Screen.fullScreen;
            }
        }
        else
        {
            Screen.fullScreen = true;
            toggle.isOn = !Screen.fullScreen;//снятие галочки при старте игры
        }


        Resolution [] resolution = Screen.resolutions;//массив
        res = resolution.Distinct().ToArray();

        string[] strRes = new string[res.Length];
        for(int i=0; i<res.Length;i++)
        {
            //strRes[i] = res[i].ToString();
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }
        //Дропдоун
        dropDown.ClearOptions();
        dropDown.AddOptions(strRes.ToList());
        if (PlayerPrefs.HasKey("Resolution"))
        {
            dropDown.value = PlayerPrefs.GetInt("Resolution");
            Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width, res[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
        }
        else
        {
            dropDown.value = res.Length - 1;//начинается с максимального резрешения экрана
            //Установка разрешения по умолчанию
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);//начинается с максимального резрешения экрана
        }
        

    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropDown.value].width, res[dropDown.value].height, Screen.fullScreen);//возможность менять текущее разрешение экрана
        PlayerPrefs.SetInt("Resolution", dropDown.value);
    }
    
    public void ScreenMode()
    {
        Screen.fullScreen = !toggle.isOn;
        if(Screen.fullScreen)
        {
            PlayerPrefs.SetInt("FullScreen", 1);//если true, то сохраняется галочка
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);//если false, то не сохраняется галочка
        }
    }
}
