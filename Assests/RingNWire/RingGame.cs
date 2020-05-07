using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCollection;
public class RingGame : MonoBehaviour
{
    private bool gameRunning = false;
    private bool timeRunning = false;
    private bool gameWon = true;
    float theTime;
    public UnityEngine.UI.Text timer;
    public DataCollectionServer con;

    private void OnTriggerEnter(Collider other) {
    //for this to detect triggers one item needs to have isTrigger on it's mesh and at least one item needs to be a rigidbody 
        if(other.tag == "Start"){
            con.SetGameId(2);
            con.StartDataLog();
            StartGame();
        }else if(other.tag == "End"&& gameRunning){
            EndGame();
        }else if(other.tag == "Hit" && gameRunning){
            con.AddEvent("Hit wire", other.name);
            LoseGame();
        }
    }
    private void Update() {
        if(gameRunning && timeRunning == false){
            timeRunning = true;
        }else if(gameRunning && timeRunning){
            theTime += Time.deltaTime;
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            timer.text = minutes + ":" + seconds;
        }
    }
    void StartGame(){
        Debug.Log("Started Game");
        gameWon = true;
        gameRunning = true;
        timer.text = "00:00";
        theTime = 0f;
    }
    void EndGame(){
        Debug.Log("Ended Game");
        con.AddEvent("Success", "" + gameWon);
        con.PushDataLog();
        gameRunning = false;
        timeRunning = false;
    }
    void LoseGame(){
        gameWon = false;
        Debug.Log("Lost Game");
        EndGame();
        timer.text = "Hit Pole";
    }
}
