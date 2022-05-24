using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    public float xBound = 29.0f;
    public float zBound = 12.0f;
    public float yPos = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // x axis limits
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, yPos, transform.position.z);
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, yPos, transform.position.z);
        }

        // z axis limits
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, yPos, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, yPos, zBound);
        }

        // y axis limits
        if (transform.position.y != yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
