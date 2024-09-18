using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject Timer;
    public Timer active;
    public GameObject scrapCount;
    public KeyCode pause;
    static public List<GameObject> dialogueBoxes;
    // Update is called once per frame

    public void Start()
    {
        dialogueBoxes = new List<GameObject>(GameObject.FindGameObjectsWithTag("DialogueUI"));
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
        pausePanel.SetActive(true);
        Timer.SetActive(false);
        scrapCount.SetActive(false);
        foreach (GameObject dia in dialogueBoxes)
        {
            dia.SetActive(false);
        }
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        scrapCount.SetActive(true);
        if (FindObjectsOfType<DialogueManager>().Any(item => item.dialogueOpen == true))
        {
            foreach (GameObject dialogue in dialogueBoxes)
            {
                dialogue.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
        }
        if (active.isOn == true)
        {
            Timer.SetActive(true);
        }
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