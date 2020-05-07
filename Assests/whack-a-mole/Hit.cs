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
    private void OnTriggerEnter(Collider other) {
        //cant hit the targets until the game starts
        if(gameControl.isGameRunning){
            if(other.tag =="Hammer" && score >= MAX) {
                moveDown = true;
                gameControl.StopGame();
            }else if (other.tag == "Hammer" && moveDown == false) {
                score++;
                gameControl.collectionServer.AddEvent("Mole" + score, gameControl.getTime());
                moveDown = true;
            }
            Debug.Log(other);
        }
    }
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
        if(moveUp){
            mole.position = Vector3.MoveTowards(mole.position,moleUp[curLocation].position, step);
            if(mole.position == moleUp[curLocation].position){
                gameControl.collectionServer.AddEvent("Mole" + (score+1) + " Appeared at", gameControl.getTime());
                moveUp = false;
            }
        }
    }

}