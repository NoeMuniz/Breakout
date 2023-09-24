using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if colliding with the ball, destorys Brick by deleting parent
        if (collision.gameObject.tag == "Ball")
        {
            float delay = 0.1f;
            Debug.Log("Ball Touched Brick");
            Destroy(this.transform.parent.gameObject, delay);
        }
        
    }
}
