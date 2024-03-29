using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public KeyCode pause;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
       
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Title Screen");
        Time.timeScale = 1;
    }

}
