using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMan : MonoBehaviour
{
    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }
}
