using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{

    public GameObject scoreCanvas;
    public GameObject character;
    public GameObject tree;
    public GameObject endCanvas;
    public GameObject pauseCanvas;
    public TimeCountScript timeCount;
    private Animator animator;

    public MovementController characterMovement;

    public AudioSource bup;
    public AudioSource music;

    public int treeCount = 50;
    public int currentTreeCount = 0;
    public int applesLostInFall = 30;

    public int appleCount = 0;

    public bool isPaused = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Get animator
        animator = character.GetComponent<Animator>();

        PlaceTrees();

        music.Play();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentTreeCount < 40)
        {
            Vector3 treePosition = new Vector3(Random.Range(-48f, 48f), 0, Random.Range(-48f, 48f));
            Vector3 treeRotation = new Vector3(-90, Random.Range(0, 360f), 0f);
            Instantiate(tree, treePosition, Quaternion.Euler(treeRotation));
            currentTreeCount++;
        }
        
        if (timeCount.timeLeft == 0)
        {
            Time.timeScale = 0;
            scoreCanvas.SetActive(false);
            endCanvas.SetActive(true);

            //Unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            music.Stop();
        }

        if (appleCount < 0)
        {
            appleCount = 0;
        }

        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void GetApple()
    {
        appleCount ++;
        animator.SetTrigger("hitTrigger");
        if (characterMovement.movementSpeed < 2500)
        {
        characterMovement.movementSpeed += 10;
        }
        bup.Play();
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            isPaused = true;
            
            //Unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Pause time
            Time.timeScale = 0;

            pauseCanvas.SetActive(true);

            music.Pause();
        }

        else
        {
            isPaused = false;

            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Start time
            Time.timeScale = 1;

            pauseCanvas.SetActive(false);

            music.UnPause();
        }

    }

    public void Restart()
    {
        characterMovement.ResetPosition();
        appleCount -= applesLostInFall;
        characterMovement.movementSpeed -= 200;
    }

    public void PlayAgain()
    {
        characterMovement.ResetPosition();
        characterMovement.movementSpeed = 200;
        appleCount = 0;
        timeCount.timeLeft = 300;
        Time.timeScale = 1;

        RemoveTrees();
        PlaceTrees();

        endCanvas.SetActive(false);
        scoreCanvas.SetActive(true);

        timeCount.StartTimer();

        music.Play();

    }

    public void PlaceTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 treePosition = new Vector3(Random.Range(-48f, 48f), 0, Random.Range(-48f, 48f));
            Vector3 treeRotation = new Vector3(-90, Random.Range(0, 360f), 0f);
            Instantiate(tree, treePosition, Quaternion.Euler(treeRotation));
            currentTreeCount++;
        }
    }

    public void RemoveTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
            Destroy(tree);
    }
}
