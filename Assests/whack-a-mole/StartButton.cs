using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataCollection;

public class StartButton : MonoBehaviour
{
    public bool isGameRunning = false;
    bool isTiming = false;
    //Text is where the game is displaying to, this is set in the Unity Editor
    public Text timer;
    float theTime;
    public DataCollectionServer collectionServer;
    
    //Unity function that gets called once per frame. Any constant game logic goes here
    void Update()
    {
        //Makes sure the timer is running if the game started
        if (isGameRunning == true && isTiming == false){
            isTiming = true;
        //Increases timer
        }else if(isGameRunning == true && isTiming == true){
            isTiming = true;
            theTime += Time.deltaTime;
            timer.text =  getTime();
        }
    }
    
    //Returns a nicely formated time string
    public string getTime(){
        string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
        string seconds = (theTime % 60).ToString("00");
        return minutes +":"+ seconds;
    }
    //Function for starting the game, is called when the user grabs the start button
    //This is set via the Unity Editor by attaching this function to the OnHandGrab option of an interactable object
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
