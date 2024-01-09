using UnityEngine;
using UnityEngine.SceneManagement;

public class Againorquit : MonoBehaviour
{
    public void Again(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
