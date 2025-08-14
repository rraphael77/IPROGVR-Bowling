using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int PinsCount = 0;
    public static int Game = 0;

    // Update is called once per frame
    void Update()
    {
        if (Game == 1)
        {
            Debug.Log("Game Over!");
            Debug.Log("Total Score: " + PinsCount);
        }
    }
}
