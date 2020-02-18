using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public bool isGameRunning = false;
    bool isTiming = false;
    public Text timer;
    float theTime;
    void Update()
    {

        if (isGameRunning == true && isTiming == false){
            isTiming = true;
        }else if(isGameRunning == true && isTiming == true){
            isTiming = true;
            theTime += Time.deltaTime;
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            timer.text =  minutes +":"+ seconds;
        }
    }
    public void GameStart(){
        isGameRunning = true;
    }
    public void StopGame(){
        isGameRunning = false;
        isTiming = false;
        Debug.Log("Game stopped");
    }

}
