using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool IsKnockedOver()
    {
        // A pin is knocked if it's tilted more than 45 degrees
        return Vector3.Angle(Vector3.up, transform.up) > 45f;
    }
}
