using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat; //the Material (color) of the traps
    public Material goalMat; //the Material (color) of the goal
    public Toggle colorblindMode; // a toggle checkbox

    // Load maze scene
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
    }

    // Quit the application
    public void QuitMaze()
    {
        Application.Quit();
    }
}
