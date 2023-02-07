using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCanvasScript : MonoBehaviour
{
    public GameManagerScript gameManager;

    public void PlayAgain()
    {
        gameManager.PlayAgain();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
