using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject ball;
    public GameObject target;
    public GameObject playerCamera;

    public Transform ground;
    public Transform boundary;
    
    public float ballDistance = 0.0f;
    public float ballThrowingForce = 0.0f;
    public float newBallTimer = 5.0f;
    private float timer;

    public static bool holdingBall = false;

    public static bool targetHit = false;

    //location information of the game boundary
    private Vector3 boundCenter;
    private Vector3 boundSize;
    private Vector3 groundCenter;
    private Vector3 groundSize;

    // Use this for initialization
    void Start () {

        //set the vector3s
        boundCenter = boundary.position;
        boundSize = boundary.localScale;
        groundCenter = ground.position;
        groundSize = ground.localScale;

        //instantiate the target at a random location within the game
        target = Instantiate(target, RandomPos(boundCenter,boundSize), Quaternion.identity);
        //target.GetComponent<Renderer>().sharedMaterial = Contact.material[0];

        //instantiate ball
        ball = Instantiate(ball, RandomPos2(groundCenter, groundSize), Quaternion.identity);
        ball.tag = "newBall";
       
        ball.GetComponent<Rigidbody>().useGravity = false;

       
		
	}
	
	// Update is called once per frame
	void Update () {


        BallLogic();

        TargetLogic();
                       

    }

    void TargetLogic()
    {
        if (targetHit)
        {
            //instantiate a new target
            target = Instantiate(target, RandomPos(boundCenter, boundSize), Quaternion.identity);
            target.tag = "newTarget";

            //destroy old target
            Destroy(GameObject.FindWithTag("oldTarget"));

            targetHit = false;
        }

     }

    void BallLogic()
    {

        if (holdingBall)
        {
            //set newBallTimer
            timer = newBallTimer;

            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
            //reset the forces
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);


            }

        }

        else if (!(holdingBall) && ball.tag == "oldBall")
        {

            if (timer <= 0)
            {

                //instantiate another ball
                ball = Instantiate(ball, RandomPos2(groundCenter, groundSize), Quaternion.identity);
                ball.tag = "newBall";
                //destroy the old one
                Destroy(GameObject.FindWithTag("oldBall"));

            }

            //count down the timer
            timer -= Time.deltaTime;

        }

    }

        Vector3 RandomPos(Vector3 center, Vector3 size)
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 
            Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        return pos;
    }

    Vector3 RandomPos2(Vector3 center, Vector3 size)
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x*5, size.x*5),0.25f, Random.Range(-size.z*5, size.z*5));

        return pos;
    }
}
