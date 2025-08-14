using UnityEngine;
using TMPro;

public class PinsTriggerL : MonoBehaviour
{
    public static bool Active = false;
    public static int PinsKnockedL = 0;

    public TMP_Text scoreText; // Assign in Inspector

    private void Update()
    {
        if (!Active) return;

        Pin[] allPins = FindObjectsOfType<Pin>();
        int knockedCount = 0;

        foreach (Pin pin in allPins)
        {
            if (pin.IsKnockedOver())
            {
                knockedCount++;
            }
        }

        PinsKnockedL = knockedCount;

        if (scoreText != null)
        {
            scoreText.text = $"Score: {PinsKnockedL} Pins";
        }

      //  Debug.Log($"Score: {PinsKnockedL} Pins");
    }
}
