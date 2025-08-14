using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int PinsCountL = 0;
    public static int PinsCountR = 0;

    public static int GameL = 0;
    public static int GameR = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameL == 1)
        {
            Debug.Log("Game Over!");
            Debug.Log("Total Score: " + PinsCountL);
        }

        else if (GameR == 1)
        {
            Debug.Log("Game Over!");
            Debug.Log("Total Score: " + PinsCountR);
        }
    }
}
