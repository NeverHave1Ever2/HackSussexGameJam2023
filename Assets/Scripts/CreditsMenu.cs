using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
