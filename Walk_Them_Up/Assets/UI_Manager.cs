using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Close_App()
    {
        Application.Quit();
    }

    public void Select_Lvl_1()
    {
        SceneManager.LoadScene("Forest");
    }
}
