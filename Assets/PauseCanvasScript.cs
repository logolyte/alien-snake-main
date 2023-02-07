using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasScript : MonoBehaviour
{

    public GameManagerScript gameManager;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        gameManager.PauseGame();
    }

}
