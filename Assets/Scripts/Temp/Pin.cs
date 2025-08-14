using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool IsKnockedOver()
    {
        bool knocked = Vector3.Angle(Vector3.up, transform.up) > 45f;

        Pin[] allPins = FindObjectsOfType<Pin>();
        int knockedCount = 0;

        foreach (Pin pin in allPins)
        {
            if (Vector3.Angle(Vector3.up, pin.transform.up) > 45f)
            {
                knockedCount++;
            }
        }

        Debug.Log($"Score: {knockedCount} Pins");
        return knocked;
    }
}
