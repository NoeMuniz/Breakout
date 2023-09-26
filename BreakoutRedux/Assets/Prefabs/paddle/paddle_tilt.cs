using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class paddle_tilt : MonoBehaviour
{
    public float RotationSpeed, MaxRotationAngle;
    string UserInput;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RotationSpeed = 5f;
        //how far paddle can tilt in each direction
        MaxRotationAngle = 45f;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        if(UserInput == "q")
        {
            Tilt(-RotationSpeed);
        }
        if(UserInput == "e")
        {
            Tilt(RotationSpeed);
        }
    }

    void ProcessInputs()
    {
        UserInput = "";
        if(Input.GetKey("q"))
        {
            UserInput = "q";
        }

        if(Input.GetKey("e"))
        {
            UserInput = "e";
        }
    }

    void Tilt(float Angle)
    {
        Vector3 rotationAngle = new Vector3(0, 0, Angle);
        this.GetComponent<Transform>().Rotate(rotationAngle);
    }
}
