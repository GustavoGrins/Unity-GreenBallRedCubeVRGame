using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundaryVR : MonoBehaviour {

    //destroy balls as they leave the game space
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "newBall")
        {
            //give it a specific tag
            other.tag = "oldBall";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "newBall")
        {
            //hold the ball
            PlayerScriptVR.holdingBall = true;
        }

    }

}
