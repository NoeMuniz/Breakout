using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPlacerScript : MonoBehaviour
{
    public GameObject ReferenceBrick;
    // Start is called before the first frame update
    void Start()
    {
        //testing methods to spawn bricks
        int levelWidth = 10;
        int levelHeight = 10;
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                float xPosition = (float)x; //the i value is indicitive of the current x position in the level generation
                float yPosition = (float)y;
                float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

                Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                Quaternion rotation = new Quaternion();

                GameObject spawningPlatform = Instantiate(ReferenceBrick, position, rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
