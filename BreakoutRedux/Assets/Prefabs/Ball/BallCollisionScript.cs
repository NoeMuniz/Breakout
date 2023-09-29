using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.gameObject.name + " has collided with: " + collision.gameObject.name);
        //if colliding with the ball, destorys Brick by deleting parent
        if (collision.gameObject.gameObject.tag == "Brick")
        {
            //Debug.Log("Ball Touched Brick");
            collision.gameObject.GetComponent<BrickScript>().DestroySelf();
        }
        
    }
}
