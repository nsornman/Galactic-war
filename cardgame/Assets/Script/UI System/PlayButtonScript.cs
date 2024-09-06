using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour

{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Modemenu()
    {
        SceneManager.LoadScene(2);
    }
}