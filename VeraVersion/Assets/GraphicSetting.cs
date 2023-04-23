using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GraphicSetting : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.names;
        dropDown.ClearOptions();//������� �������� �����
        dropDown.AddOptions(QualitySettings.names.ToList());//������� ������ �������
        if (PlayerPrefs.HasKey("Quality"))
        {
            dropDown.value = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }
        else
        {
            dropDown.value = QualitySettings.GetQualityLevel(); //���������� ������ �������� ������ �������
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropDown.value);
        PlayerPrefs.SetInt("Quality", dropDown.value);
    }
}
