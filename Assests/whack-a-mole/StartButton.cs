using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataCollection;

public class StartButton : MonoBehaviour
{
    public bool isGameRunning = false;
    bool isTiming = false;
    public Text timer;
    float theTime;
    public DataCollectionServer collectionServer;
    void Update()
    {

        if (isGameRunning == true && isTiming == false){
            isTiming = true;
        }else if(isGameRunning == true && isTiming == true){
            isTiming = true;
            theTime += Time.deltaTime;
            timer.text =  getTime();
        }
    }
    public string getTime(){
        string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
        string seconds = (theTime % 60).ToString("00");
        return minutes +":"+ seconds;
    }
    //Function for starting the game, is called when the user grabs the start button
    public void GameStart(){
        collectionServer.SetGameId(1);
        isGameRunning = true;
        collectionServer.StartDataLog();
    }
    //Function for ending the game, is called when the user hits the last mole
    public void StopGame(){
        collectionServer.PushDataLog();
        isGameRunning = false;
        isTiming = false;
        Debug.Log("Game stopped");
    }

}
