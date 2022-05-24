using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player1Unit2Mvt : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;
    public Vector3 distance;
    private Rigidbody pARB;
    private Rigidbody pBRB;
    public float speed;
    public float brokeSpeed = 1000.0f;
    public float secondVerticInput;
    public float maxDist = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodies
        pARB = playerA.GetComponent<Rigidbody>();
        pBRB = playerB.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = playerA.transform.position - playerB.transform.position;

        // Vertical input for the second unit
        secondVerticInput = Input.GetAxis("DistanceP1");
        if (distance.magnitude > maxDist)
        {
            secondVerticInput = 0.0f;
            pBRB.AddForce(distance.normalized * Time.deltaTime * brokeSpeed);
        }
        else
        {
            pBRB.AddForce(distance.normalized * Time.deltaTime * speed * secondVerticInput, ForceMode.Impulse);
        }
    }
}
