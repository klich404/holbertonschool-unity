using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invTog;
    private bool invertY;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            invertY = false;
        else
            invertY = true;
        invTog.isOn = invertY;
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }

    public void Apply()
    {
        if (invTog.isOn)
            PlayerPrefs.SetInt("Y", 1);
        else
            PlayerPrefs.SetInt("Y", 0);
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }
}
