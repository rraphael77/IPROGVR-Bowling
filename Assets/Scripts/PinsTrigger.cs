using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        ScoreManager.PinsCount++;

        Debug.Log($"Score: {ScoreManager.PinsCount} Pins");
    }
}