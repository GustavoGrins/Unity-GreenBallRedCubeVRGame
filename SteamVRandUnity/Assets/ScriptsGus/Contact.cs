using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour {

    //public static Material[] material;
    //Renderer rend;

    private void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.sharedMaterial = material[0];
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "oldBall")
        {
            ScoreManager.score += 10;
            PlayerScript.targetHit = true;
            this.tag = "oldTarget";
            //change the color of the target
            //rend.sharedMaterial = material[1];
        }

        

    }

}
