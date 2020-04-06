using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RingGame : MonoBehaviour
{
    private bool gameRunning = false;
    private bool timeRunning = false;
    float theTime;
    public UnityEngine.UI.Text timer;
    private void OnTriggerEnter(Collider other) {
    //for this to detect triggers one item needs to have isTrigger on it's mesh and at least one item needs to be a rigidbody 
        Debug.Log(other);
        Debug.Log("Collision Deteced");
        if(other.tag == "Start"){
            StartGame();
        }else if(other.tag == "End"&& gameRunning){
            EndGame();
        }else if(other.tag == "Hit" && gameRunning){
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
        gameRunning = true;
        timer.text = "00:00";
        theTime = 0f;
    }
    void EndGame(){
        gameRunning = false;
        timeRunning = false;
    }
    void LoseGame(){
        EndGame();
        timer.text = "Hit Pole";
    }
}
