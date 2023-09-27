using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Spawning_Behavior : MonoBehaviour
{
    public GameObject ReferenceBall;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //controls for tesing launch and spawn ball functions
        if (Input.GetKeyDown("w"))
        {
            Launchball();
        }
        if (Input.GetKeyDown("s"))
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        //running into issues when spawning while the platform is rotated. it causes morphing of the ball
        //set spawn position data
        float xOffset = 0f;
        float yOffset = 1f;
        float xPosition = this.transform.position.x + xOffset; 
        float yPosition = this.transform.position.y + yOffset;
        float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

        //created varaibles to hold spawn position data
        Vector3 position = new Vector3(xPosition, yPosition, zPosition);
        Quaternion rotation = Quaternion.identity;

        //spawns the ball at the designated position.
        GameObject ball = Instantiate(ReferenceBall, position, rotation);        
        
        //make paddle parent of the ball
        ball.transform.parent = this.gameObject.transform;
        //ball.transform.localScale = new Vector3(1f, 1f, 1f); //brute force resetting the balls scale since it seems to be messed up and inheriting form the parent. dont know why it only affects the child when the parent is at a rotated position
        


        // Disable collisions with the object being attached
        if (ball.GetComponent<CircleCollider2D>())
        {
            ball.GetComponent<CircleCollider2D>().enabled = false;
        }

        // Don't allow physics to affect the object and allow it to follow the paddle
        if (ball.GetComponent<Rigidbody2D>())
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void Launchball()
    {
        //perhaps checking if this.gameObject.transform.childCount() == 1 would be an equivalent check
        if (holdingBallCheck() == true)
        {
            //assign variables to make accessing the child(ball)'s transform and rigidbody2d easier
            Transform heldBallTransform = this.gameObject.transform.GetChild(0);
            Rigidbody2D heldBallRB = heldBallTransform.GetComponent<Rigidbody2D>();
            CircleCollider2D heldBallCollider = heldBallTransform.transform.GetComponent<CircleCollider2D>();

            //Deparent the ball form the paddle
            heldBallTransform.transform.parent = null;

            // Disable collisions with the ball to avoid collisions while attatched.
            if (heldBallCollider)
            {
                heldBallCollider.enabled = true;
            }

            //allow physics to affect the ball and allow it to detatch from the paddle
            if (heldBallRB)
            {
                heldBallRB.isKinematic = false;
            }



            //Set balls velocity to be equal to the paddle's velocity to allow the ball to maintain momentum after detatching from the paddle
            heldBallRB.velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;

            //launch the ball vertically
            float verticalLaunchForce = 500;
            float horizontalLaunchForce = 0;
            heldBallRB.AddForce(new Vector2(horizontalLaunchForce, verticalLaunchForce));
        }
        
    }

    bool holdingBallCheck()
    {
        //simple implementation of the function that checks the children of the paddle and returns true if any child has the "Ball" tag
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            string childTag = child.tag;
            // Do something based on tag
            if(childTag == "Ball")
            {
                return true;
            }              
        }           
        return false;
    }
}
