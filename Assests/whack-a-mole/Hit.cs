using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {
    public Transform[] moleDown = new Transform[4];
    public Transform[] moleUp = new Transform[4];
    public Transform mole;
    private bool moveDown = false;
    private bool moveUp = false;
    public float speed = 1.0f;
    public StartButton gameControl;
    private int score = -1;
    private int curLocation = 0;
    public const int MAX = 5;
    public bool isGameRunning = false;
    
    //Unity function that gets called whenever a collison between two objects happens
    //Collider other is the object that has collided with the object this script is attached to 
    private void OnTriggerEnter(Collider other) {
        //Checks if game is running so you can't score points if game isn't on
        if(gameControl.isGameRunning){
            //Checks if the mole was hit with a hammer and if it is time to stop the game
            if(other.tag =="Hammer" && score >= MAX) {
                moveDown = true;
                gameControl.StopGame();
            //Make sure that it will only add points if the mole is not moving down
            }else if (other.tag == "Hammer" && moveDown == false) {
                score++;
                gameControl.collectionServer.AddEvent("Mole" + score, gameControl.getTime());
                moveDown = true;
            }
            Debug.Log(other);
        }
    }
    //Called once a frame, any logic that needs to run all the time goes here
    private void Update() {
        
        float step = speed * Time.deltaTime;
        //moves the mole into primary starting position
        if(isGameRunning && score < 0){
            score = 0;
            moveDown = true;
        }
        // moves the mole to a postion until it reaches it's target. Position is below the table. Then sets the new postion
        // lastly moves the mole to the new position, this time its above the table
        if(moveDown){
            mole.position = Vector3.MoveTowards(mole.position, moleDown[curLocation].position, step);
            if(mole.position == moleDown[curLocation].position){
                curLocation = Random.Range(0, (moleDown.Length-1));
                //postitions the mole directly below where it will appear
                //makes it look nicer
                mole.position = moleDown[curLocation].position;
                moveDown = false;
                moveUp = true;
            }
        }
        //Moves the mole up to its position so that it can be hit.
        if(moveUp){
            mole.position = Vector3.MoveTowards(mole.position,moleUp[curLocation].position, step);
            if(mole.position == moleUp[curLocation].position){
                gameControl.collectionServer.AddEvent("Mole" + (score+1) + " Appeared at", gameControl.getTime());
                moveUp = false;
            }
        }
    }

}
