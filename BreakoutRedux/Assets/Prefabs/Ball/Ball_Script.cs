using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    public int TestForce = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pressing arrow keys applies test force to the ball
        if(Input.GetKeyDown("up"))
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, TestForce));
        }
        if (Input.GetKeyDown("down"))
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -TestForce));
        }
        if (Input.GetKeyDown("left"))
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-TestForce, 0));
        }
        if (Input.GetKeyDown("right"))
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(TestForce, 0));
        }
    }
}
