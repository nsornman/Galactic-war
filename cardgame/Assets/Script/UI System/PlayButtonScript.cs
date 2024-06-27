using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour

{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Modemenu()
    {
        SceneManager.LoadSceneAsync(3);
    }
}