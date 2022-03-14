using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    int level;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (level == 4)
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene(level + 1);
    }
}
