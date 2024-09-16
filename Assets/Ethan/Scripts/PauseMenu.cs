using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Timer;
    public GameObject ScrapCount;
    public GameObject blacklight;
    public KeyCode pause;
    public List <GameObject> dialogueManagers;
    public GameObject dialogueBox;
 

    public void Start()
    {
        dialogueManagers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Dialogue"));
    }


    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            Pause();
        }

    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        Timer.SetActive(false);
        ScrapCount.SetActive(false);
        dialogueBox.SetActive(false);
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Timer.SetActive(true);
        ScrapCount.SetActive(true);
        //foreach (GameObject DialogueManager in dialogueManagers)
        //{
            
        //}
        //else
        //{
            //Time.timeScale = 1;
        //}
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title Screen");
    }
    public void Restart(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
