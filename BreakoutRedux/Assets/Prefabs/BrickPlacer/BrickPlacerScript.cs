using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPlacerScript : MonoBehaviour
{
    public GameObject ReferenceBrick;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBricks()
    {
        //testing methods to spawn bricks
        Vector2 rawCameraDimensions = CalculateScreenSize(Camera.main);

        int levelWidth = Mathf.RoundToInt(rawCameraDimensions.x -1 );//-1 temporary measure to allow a gap between the right wall and the bricks
        int levelHeight = Mathf.RoundToInt(rawCameraDimensions.y);
        int placementFloorY = Mathf.RoundToInt(rawCameraDimensions.y / 2);//temporary measure to place bricks halfway up the screen. used to set y offset
        int placementFloorX = Mathf.RoundToInt(2);//temporary measure to place bricks 2 units away from the left edge. used to set x offset
        for (int x = placementFloorX; x < levelWidth; x++)
        {
            for (int y = placementFloorY; y < levelHeight; y++)
            {
                int placementChance = 100;
                if (UnityEngine.Random.Range(1, 100+1) <= placementChance)//Random.Range is not max inclusive when using INT
                {
                    float xPosition = (float)x; //the i value is indicitive of the current x position in the level generation
                    float yPosition = (float)y;
                    float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

                    Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);
                    spawnPosition = this.gameObject.transform.position + spawnPosition; //allows spawning relative to the position of the gameObject

                    Quaternion rotation = new Quaternion();


                    GameObject spawningPlatform = Instantiate(ReferenceBrick, spawnPosition, rotation);
                }
            }
        }
    }

    Vector2 CalculateScreenSize(Camera camera)
    {
        if(camera != null)
        {
            // Calculate the camera height in world units.
            float cameraHeight = camera.orthographicSize * 2;

            // Calculate the camera width in world units based on the aspect ratio.
            float cameraWidth = cameraHeight * camera.aspect;

            return new Vector2(cameraWidth, cameraHeight);
        }
        else
        {
            Debug.Log("CAMERA NOT FOUND");
            return new Vector2(-1,-1);//represents camera not found
        }
    }
}
