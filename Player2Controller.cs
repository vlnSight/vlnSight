using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;
    public float movementSpeed;
    private float trueSpeed;
    private float horizontalInput;
    private float verticalInput;
    private float secondHorizInput;
    public float angularSpeed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Interpreting the input
        horizontalInput = Input.GetAxis("HorizontalP2");
        verticalInput = Input.GetAxis("VerticalP2");

        // Removing the speed boost that appears when going diagonally
        if (horizontalInput != 0 && verticalInput != 0)
        {
            trueSpeed = movementSpeed * 0.707106781f;
        }
        else
        {
            trueSpeed = movementSpeed;
        }

        // Updating the position
        transform.position += new Vector3(horizontalInput * trueSpeed * Time.deltaTime, 0, verticalInput * trueSpeed * Time.deltaTime);

        // Rotate the secondary unit around the central unit
        secondHorizInput = Input.GetAxis("AngleP2");

        distance = Vector3.Distance(playerB.transform.position, playerA.transform.position);

        transform.Rotate(0, angularSpeed / distance * secondHorizInput, 0);
    }
}
