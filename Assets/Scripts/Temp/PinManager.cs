using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public Transform pinParent; 
    private GameObject[] pins;
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;

    void Start()
    {
        pins = new GameObject[pinParent.childCount];
        for (int i = 0; i < pinParent.childCount; i++)
        {
            pins[i] = pinParent.GetChild(i).gameObject;
        }

        initialPositions = new Vector3[pins.Length];
        initialRotations = new Quaternion[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            initialPositions[i] = pins[i].transform.position;
            initialRotations[i] = pins[i].transform.rotation;
        }
    }

    public void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.position = initialPositions[i];
            pins[i].transform.rotation = initialRotations[i];

            Rigidbody rb = pins[i].GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public int CountKnockedOverPins()
    {
        int count = 0;
        foreach (GameObject pin in pins)
        {
            var pinScript = pin.GetComponent<Pin>();
            if (pinScript == null)
            {
                Debug.LogError("Pin script missing on: " + pin.name);
                continue;
            }

            if (pinScript.IsKnockedOver())
                count++;
        }
        Debug.Log("Knocked over pins: " + count);
        return count;
    }
}
