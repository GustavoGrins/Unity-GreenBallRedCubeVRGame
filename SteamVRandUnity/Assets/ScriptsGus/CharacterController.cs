using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 10.0F;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

        float forwardMove = Input.GetAxis("Vertical") * speed;
        float sideMove = Input.GetAxis("Horizontal") * speed;

        //to avoid jittering around
        forwardMove *= Time.deltaTime;
        sideMove *= Time.deltaTime;

        transform.Translate(sideMove, 0, forwardMove);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
		
	}
}
