using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf()
    {
        float delay = 0.1f;
        Debug.Log("Ball Touched Brick");
        Destroy(this.gameObject, delay);
    }
}
