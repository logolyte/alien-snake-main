using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCountScript : MonoBehaviour
{

    public GameManagerScript gameManager;
    public TMPro.TextMeshProUGUI appleText;

    // Start is called before the first frame update
    void Start()
    {
        //Get Apple Text
        appleText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        appleText.text = gameManager.appleCount.ToString();
    }
}
