using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public GameManagerScript gameManager;



    void Start()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter()
    {
        gameManager.GetApple();
        Destroy(gameObject);
        gameManager.currentTreeCount--;
    }
}
