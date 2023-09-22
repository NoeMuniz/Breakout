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
        //pressing space applies test force to the ball
        if(Input.GetKeyDown("space"))
        {
            //apply an force to the ball for testing
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(TestForce, TestForce));
        }
    }
}
