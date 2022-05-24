using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;
    public Vector3 distance;
    private Rigidbody pARB;
    private Rigidbody pBRB;
    public float maxDist = 12.0f;
    public float forceMax = 50.0f;
    private bool tendu = false;

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

        // Condition for when the two units are too far apart
        if (distance.magnitude > maxDist)
        {
            devientTendu();
        }
        else
        {
            tendu = false;
        }
    }

    // Applying the force, once, when the conditions are met
    void devientTendu()
    {
        if (!tendu)
        {
            tendu = true;
            float ropeForce;

            if (pBRB.velocity.magnitude > forceMax)
            {
                ropeForce = forceMax;
                UnityEngine.Debug.Log("Lien brisé!");
            }
            else
            {
                ropeForce = pBRB.velocity.magnitude;
            }
            Vector3 force2Add = distance.normalized * ropeForce;

            pBRB.AddForce(force2Add, ForceMode.Impulse);
            pARB.AddForce(-force2Add, ForceMode.Impulse);

            UnityEngine.Debug.Log("Force appliquée : " + force2Add.magnitude);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Border touched!");
    }
}
