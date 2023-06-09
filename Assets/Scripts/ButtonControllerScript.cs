using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial Level");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }
    public void EndGame()
    {
        Application.Quit();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("Tutorial Level");
        }

        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene("MEDLevel");
        }

        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("HARDLevel");
        }

        if (Input.GetKey(KeyCode.X))
        {
            Application.Quit();
        }

    }

}
