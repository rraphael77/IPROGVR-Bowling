using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsTriggerL : MonoBehaviour
{
    public static bool Active = false;

    public static int PinsKnockedL = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (Active)
        {
            PinsKnockedL--;
            Debug.Log($"Score: {PinsKnockedL} Pins");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Active)
        {
            PinsKnockedL++;
            Debug.Log($"Score: {PinsKnockedL} Pins");
        }
    }
}