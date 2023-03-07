using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenuScript : MonoBehaviour
{
    bool active = false;
    public GameObject EscMenu;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && active == true)
        {
            EscMenu.SetActive(false);
            active = false;
            Time.timeScale = 1;

            goto Point;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && active == false)
        {
            EscMenu.SetActive(true);
            active = true;
            Time.timeScale = 0;

            goto Point;
        }

    Point:;
        
    }

    public void Resume()
    {
        EscMenu.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
