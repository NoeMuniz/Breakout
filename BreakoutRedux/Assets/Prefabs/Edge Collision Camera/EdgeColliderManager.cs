using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeColliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        CreateColliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateColliders()
    {
        if (this.gameObject.GetComponent<EdgeCollider2D>())
        {
            //return if the collider already exists.
            return;
        }
        else
        {
            //create variable for quick camera referecnce access
            Camera cam = this.gameObject.GetComponent<Camera>();

            //create EdgeCollider2D component
            this.gameObject.AddComponent<EdgeCollider2D>();
            EdgeCollider2D collider = this.gameObject.GetComponent<EdgeCollider2D>();

            //collider is initialized at the origin with offset 0,0. It needs to be offset by the negative transform of the camera to be at the correct position
            collider.offset = -cam.transform.position;


            //create relative points for each corner of the camera
            //in viewport for camera, the values range from 0-1 on x and y axis.
            Vector2 topLeftCorner = new Vector2(0f, 1f);
            Vector2 topRightCorner = new Vector2(1f,1f);
            Vector2 botRightCorner = new Vector2(1f, 0f);
            Vector2 botLeftCorner = new Vector2(0f, 0f);

            //conver points to world coords and add to the Edge collider
            List<Vector2> vectorList = new List<Vector2>();
            
            vectorList.Add(cam.ViewportToWorldPoint(topLeftCorner));
            vectorList.Add(cam.ViewportToWorldPoint(topRightCorner));
            vectorList.Add(cam.ViewportToWorldPoint(botRightCorner));
            vectorList.Add(cam.ViewportToWorldPoint(botLeftCorner));
            vectorList.Add(cam.ViewportToWorldPoint(topLeftCorner));//done twice to fully seal the collider into a box 
            collider.SetPoints(vectorList);
        }
    }
}
