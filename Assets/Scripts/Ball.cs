using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 resetPosition = new Vector3(-4f, 1.33f, 17.1f);

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetBall()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Invoke(nameof(ResetPosition), Random.Range(1f, 2f));
    }
    private void ResetPosition()
    {
        rb.position = resetPosition;
    }
}
