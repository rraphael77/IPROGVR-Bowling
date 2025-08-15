using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int PinsCountL = 0;
    public static int PinsCountR = 0;

    public static int GameL = 1;
    public static int GameR = 1;

    public TextMeshProUGUI FrameL;
    public TextMeshProUGUI ScoreL;

    public TextMeshProUGUI FrameR;
    public TextMeshProUGUI ScoreR;

    // Update is called once per frame
    void Update()
    {
        FrameL.text = "Game: " + GameL + " Frame: " + BallTriggerL.frame;
        ScoreL.text = "Score: " + PinsCountL + " Pins";

        FrameR.text = "Game: " + GameR + " Frame: " + BallTriggerR.frame;
        ScoreR.text = "Score: " + PinsCountR + " Pins";

        if (GameL == 2)
        {
            Debug.Log("Game Over!");
            Debug.Log("Total Score: " + PinsCountL);
        }

        else if (GameR == 2)
        {
            Debug.Log("Game Over!");
            Debug.Log("Total Score: " + PinsCountR);
        }
    }
}
