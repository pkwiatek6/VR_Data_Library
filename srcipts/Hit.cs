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
    private int score = 0;
    private int curLocation = 0;
    public const int MAX = 5;
    private void OnTriggerEnter(Collider other) {
        if(other.tag =="Hammer" && score >= MAX) {
            gameControl.StopGame();
            return;
        }else if (other.tag == "Hammer" && /*moveUp == false &&*/ moveDown == false) {
            score++;
            moveDown = true;
        }
        Debug.Log(other);
    }
    private void Update() {
        // moves the mole to a postion until it reaches it's target. Position is below the table. Then sets the new postion
        // lastly moves the mole to the new position, this time its above the table
        float step = speed * Time.deltaTime;
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
                moveUp = false;
            }
        }
    }
}
