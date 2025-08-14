using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrofgravityt : MonoBehaviour
{
    public Vector3 customCenterOfMass = new Vector3(-0.1f, 0.1f, 0f); // 0.04 units to the left
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = customCenterOfMass;
    }
}
