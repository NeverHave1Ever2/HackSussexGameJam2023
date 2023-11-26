using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.IMGUIModule;

public class Settings : MonoBehaviour
{
    [SerializeField]
    Slider s;
    [SerializeField]
    Button b;

    //public float hSliderValue = 0.0F;
    public int[,] resolutions = { { 640, 480 }, { 1280, 960 }, { 1920, 1080 } };
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        s.minValue = 0.0F;
        s.maxValue = 2.0F;
    }
    /*
    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 3.0F);
        if (GUI.Button(new Rect(25,70,100,30), "Apply"))
        {
            int ActualResolution = Mathf.FloorToInt(hSliderValue);
            Screen.SetResolution(resolutions[ActualResolution, 0], resolutions[ActualResolution, 1], true);
        }
    }
    */
    public void ResolutionUpdate(float res)
    {
       // Debug.Log("resolution:" + res);
        Debug.Log("resolution:" + s.value);
        /*
        if (b.onClick)
        {
            int actualres = Mathf.FloorToInt(s.value);
            Screen.SetResolution(resolutions[actualres, 0], resolutions[actualres, 1], true);
        }
        */
        //int actualres = Mathf.FloorToInt(s.value);
        b.onClick.AddListener(OnApplyButton);
    }

    public void OnApplyButton()
    {
        int pointer = Mathf.RoundToInt(s.value);
        Debug.Log(pointer);
        Screen.SetResolution(resolutions[pointer, 0], resolutions[pointer, 1], true);
        Debug.Log("Width" + resolutions[pointer, 0] + "Height" + resolutions[pointer, 1]);
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
