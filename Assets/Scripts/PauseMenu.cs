using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = togglepause();

        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            GUILayout.Label("Game Paused");
            if(GUILayout.Button("Return to play"))
            {
                isPaused = togglepause();
            }
            if(GUILayout.Button("Return to menu"))
            {
                SceneManager.LoadScene(0);
                isPaused = togglepause();
            }
        }
    }

    bool togglepause()
    {
        if(Time.timeScale == 0F)
        {
            Time.timeScale = 1F;
            return false;
        } else
        {
            Time.timeScale = 0F;
            return true;
        }
    }
}
