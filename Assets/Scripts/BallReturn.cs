using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    public Vector3 returnPosition = new Vector3(-4f, 0.5f, 17f);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Return")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero; // Stop any movement
            rb.angularVelocity = Vector3.zero; // Stop spinning
            rb.position = returnPosition; // Instantly move the ball
            // Alternatively, you can use:
            // rb.MovePosition(returnPosition);
        }
    }
}