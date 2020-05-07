/* Logic for the Memory Game */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;
using DataCollection;

public class MemGame : MonoBehaviour
{
    //Seconds to wait before showing next color in sequence
    public int memTime = 3;
    //Sequence to be generated
    private int[] genSequence = new int[3];
    //Sequence that the player has entered
    private int[] plyrSequence = new int[3];
    //Color button changes to when disabled
    public Material disabledMat;
    public Text textDisplay;
    private IEnumerator showSequence;
    //Which number in the sequence the player is currently on
    private int whichSeq = 0;
    private bool stoppedShowing = false;
    private bool gameOver = false;
    public GameObject resetButton;
    public GameObject startButton;
    // Data to push
    float timer, sequenceEndTime, gameEndTime;
    public DataCollectionServer con;

    private void Start(){
        resetButton.SetActive(false);
    }

    private void Update() {
        timer += Time.deltaTime;
        // if player pushed a button stop showing the sequence
        if(plyrSequence[0] != 0 && !stoppedShowing){
            StopCoroutine(showSequence);
            Debug.Log("Stopped Showing Sequence");
            sequenceEndTime = timer;
            textDisplay.text = "Please enter sequence";
            stoppedShowing = true;
        }    
        if(plyrSequence[plyrSequence.Length-1] != 0 && !gameOver){
            EndGame();
        }
    }

    public void StartGame(){
        Debug.Log("Mem Test Started");
        GenerateSequence();
        showSequence = ShowSequence();
        StartCoroutine(showSequence);
        timer = 0f;
        con.SetGameId(3);
        con.StartDataLog();
    }

    public void EndGame(){
        Debug.Log("Game Ended");
        if(genSequence.SequenceEqual(plyrSequence)){
            textDisplay.text = "Good Memory";
        }else{
            int mistakes = 0;

            for (int i = 0; i < plyrSequence.Length; i++)
            {
                if (!plyrSequence[i].Equals(genSequence[i])) {
                    mistakes += 1;
                }
            }
            textDisplay.text = "Mistakes Made: " + mistakes;
            con.AddEvent("Mistakes", mistakes.ToString());
        }
        gameOver = true;
        resetButton.SetActive(true);

        gameEndTime = timer - sequenceEndTime;

        // Converts timer values to strings of mm:ss for time
        string sequenceTime = Mathf.Floor((sequenceEndTime % 3600) / 60).ToString("00") + ":" + (sequenceEndTime % 60).ToString("00") + ":" + (sequenceEndTime * 1000f % 100).ToString("00");
        string gameTime = Mathf.Floor((gameEndTime % 3600) / 60).ToString("00") + ":" + (gameEndTime % 60).ToString("00") + ":" + (sequenceEndTime * 1000f % 100).ToString("00");

        con.AddEvent("Sequence time", sequenceTime);
        con.AddEvent("Game Time", gameTime);

        //Converts gen Sequence to string
        string strSequence = string.Join(",",genSequence.Select(x=>x.ToString()).ToArray());  
        con.AddEvent("Generated Sequence", strSequence);
        //Converts player sequence to string
        strSequence = string.Join(",",plyrSequence.Select(x=>x.ToString()).ToArray());  
        con.AddEvent("Player Sequence", strSequence);

        con.PushDataLog();
    }

    public void ResetGame(){
        whichSeq = 0;
        plyrSequence = new int[3];
        stoppedShowing = false;
        gameOver = false;
        textDisplay.text = "Push Button to start Game";
        startButton.SetActive(true);
        resetButton.SetActive(false);
    }

    public void ButtonPress(GameObject buttonObj){
        if(!gameOver){
            switch (buttonObj.tag) {
                case "1":
                    Debug.Log("Button 1 Pressed");
                    plyrSequence[whichSeq] = 1;
                    whichSeq++;
                    break;
                case "2":
                    Debug.Log("Button 2 Pressed"); 
                    plyrSequence[whichSeq] = 2;
                    whichSeq++;
                    break;
                case "3":
                    Debug.Log("Button 3 Pressed");
                    plyrSequence[whichSeq] = 3;
                    whichSeq++;
                    break;
                case "4":
                    Debug.Log("Button 4 Pressed");
                    plyrSequence[whichSeq] = 4;
                    whichSeq++;
                    break;
                case "5":
                    Debug.Log("Button 5 Pressed");
                    plyrSequence[whichSeq] = 5;
                    whichSeq++;
                    break;
                case "6":
                    Debug.Log("Button 6 Pressed");
                    plyrSequence[whichSeq] = 6;
                    whichSeq++;
                    break;
                case "startButton":
                    StartGame();
                    startButton.SetActive(false);
                    Debug.Log("SB404");
                    break;
                default:
                    Debug.Log("Unknown Input, did you set the correct tag?");
                    break;
            }
        }
        if(whichSeq + 1 == plyrSequence.Length){

        }
    }
    //Changes the button to diabledMat and makes it so you cant press it again for a while
    private void disableButton(GameObject buttonObj){
        //gets original Matrial on obj
        Material originalMat = buttonObj.GetComponent<Renderer>().material;
        buttonObj.GetComponent<Renderer>().material = disabledMat;


    }
    private void GenerateSequence(){
        //genearte an amount of numbers based on difficulty
        for (int i = 0; i < genSequence.Length; i++) {
            genSequence[i] = Random.Range(1,6);
        }
    }
    //coroutine for showing number ticking down, since unity would be sinlge threaded instead and we dont want to pause the entire game
    IEnumerator ShowSequence() {
        for (int i = 0; i < genSequence.Length; i++){
            switch (genSequence[i]){
                case 1:
                    textDisplay.text = string.Format("{0} Red", i + 1);
                    break;
                case 2:
                    textDisplay.text = string.Format("{0} Orange", i + 1);
                    break;
                case 3:
                    textDisplay.text = string.Format("{0} Yellow", i + 1);
                    break;
                case 4:
                    textDisplay.text = string.Format("{0} Green", i + 1);
                    break;
                case 5:
                    textDisplay.text = string.Format("{0} Blue", i + 1);
                    break;
                case 6:
                    textDisplay.text = string.Format("{0} Magenta", i + 1);
                    break;
                default:
                    textDisplay.text = string.Format("{0} Not a color", i + 1);
                    break;
            }
            yield return new WaitForSeconds(memTime);
            if(i >= genSequence.Length - 1){
                //infinte loop only if the user never presses a button
                    i = -1;
            }
        } 
        //EnableButtons();
    }
}
