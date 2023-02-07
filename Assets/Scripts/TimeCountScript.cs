using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TimeCountScript : MonoBehaviour
{

    public GameManagerScript gameManager;

    public int timeLeft = 300;

    public TMPro.TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
        

    }

    // Update is called once per frame
    void Update()
    {
        //Update text
        timeText.text = timeLeft.ToString();
    }

    //Remove one second from timer
    IEnumerator LoseTime()
    {
        while (gameManager.isPaused == false && timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void StartTimer()
    {
        StartCoroutine("LoseTime");
    }
}
