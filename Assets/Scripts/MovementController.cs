using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float movementSpeed = 6f;
    private Rigidbody rigidbody;

    float horizontalInput;
    float verticalInput;

    private Animator animator;

    private string movementDirection = "forward";

    Vector3 movement;



    // Start is called before the first frame update
    void Start()
    {

        //Get animator
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Check for movement input
        
        if (Input.GetKeyDown("w"))
        {
            movementDirection = "forward";
        }

        if (Input.GetKeyDown("a"))
        {
            movementDirection = "left";
        }

        if (Input.GetKeyDown("s"))
        {
            movementDirection = "backwards";
        }

        if (Input.GetKeyDown("d"))
        {
            movementDirection = "right";
        }


        //Calculate movement
        switch (movementDirection)
        {
            case "forward":
                movement = new Vector3(0, 0, movementSpeed * Time.deltaTime);
                break;
            case "left":
                movement = new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
                break;
            case "backwards":
                movement = new Vector3(0, 0, -movementSpeed * Time.deltaTime);
                break;
            case "right":
                movement = new Vector3(movementSpeed * Time.deltaTime, 0);
                break;
        }

    }

    void FixedUpdate()
    {
     //Move character
     rigidbody.velocity = movement;

     //Rotate character
     switch (movementDirection) 
        {
            case "forward":
                rigidbody.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "backwards":
                rigidbody.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case "left":
                rigidbody.rotation = Quaternion.Euler(0, -90, 0);
                break;
            case "right":
                rigidbody.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void ResetPosition()
    {
        rigidbody.position = new Vector3(0f, 0.05f, 0f);
    }
}
