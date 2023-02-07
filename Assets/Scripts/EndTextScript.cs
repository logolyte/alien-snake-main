using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTextScript : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TimeCountScript timeCountScript;

    public TMPro.TextMeshProUGUI endText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endText.text = "You got " + gameManager.appleCount.ToString() + " apples, well done!";
    }
}
