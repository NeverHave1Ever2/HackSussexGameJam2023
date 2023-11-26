using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.IMGUIModule;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    Slider s;

    public float hSliderValue = 0.0F;
    public int[,] resolutions = { { 640, 480 }, { 1280, 960 }, { 1920, 1080 } };
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    
    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 3.0F);
        if (GUI.Button(new Rect(25,70,100,30), "Apply"))
        {
            int ActualResolution = Mathf.FloorToInt(hSliderValue);
            Screen.SetResolution(resolutions[ActualResolution, 0], resolutions[ActualResolution, 1], true);
        }
    }

    public void ResolutionUpdate(float res)
    {
       // Debug.Log("resolution:" + res);
        Debug.Log("resolution:" + s.value);
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
