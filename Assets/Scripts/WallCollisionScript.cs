using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionScript : MonoBehaviour
{
    public GameManagerScript gameManager;
    
    private void OnTriggerEnter()
    {
        gameManager.Restart();
    }
}
