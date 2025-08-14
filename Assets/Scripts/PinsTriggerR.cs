using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsTriggerR : MonoBehaviour
{
    public static bool Active = false;

    public static int PinsKnocked = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (Active)
        {
            PinsKnocked--;
            Debug.Log($"Score: {PinsKnocked} Pins");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Active)
        {
            PinsKnocked++;
            Debug.Log($"Score: {PinsKnocked} Pins");
        }
    }
}