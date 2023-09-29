using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    int TestForce = 1000; //used for testing
    string UserInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }

    void FixedUpdate()
    {
        ApplyUserInput();
    }

    void GetUserInput()
    { 
        UserInput = "";
        //pressing arrow keys applies test force to the ball
        if (Input.GetKeyDown("up"))
        {
            UserInput = "up";
        }
        if (Input.GetKeyDown("down"))
        {
            UserInput = "down";
        }
        if (Input.GetKeyDown("left"))
        {
            UserInput = "left";
        }
        if (Input.GetKeyDown("right"))
        {
            UserInput = "right";
        }
    }
    void ApplyUserInput()
    {
        //pressing arrow keys applies test force to the ball
        if (UserInput == "up")
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, TestForce));
        }
        if (UserInput == "down")
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -TestForce));
        }
        if (UserInput == "left")
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-TestForce, 0));
        }
        if (UserInput == "right")
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(TestForce, 0));
        }
    }
}