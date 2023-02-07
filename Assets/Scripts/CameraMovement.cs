﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraYOffset = 20f;

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y + cameraYOffset, character.transform.position.z);
    }
}
