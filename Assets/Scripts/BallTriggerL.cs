using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerL : MonoBehaviour
{
    public Animator BallBlockerL;

    public PinsManager pinsManager;

    private bool ballTrigger = false;
    private bool spare = false;
    private bool strike = false;

    public static int frame = 1;

    private int turn = 0;
    private int tempCount = 0;
    private int spareCount = 0;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            turn++;
            StartCoroutine(BallTrigger());

            Debug.Log("Left Frame: " + frame + "Turn: " + turn);
        }
    }

    public void SpareRoutine()
    {
        BallBlockerL.SetTrigger("Trigger");
        pinsManager.toggleL2 = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaneStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < 10)
        {
            if (turn == 1 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerL.PinsKnocked == 10)    // If Strike
                {
                    turn = 0;
                    frame++;

                    ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    tempCount = PinsTriggerL.PinsKnocked;
                    ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;
                    SpareRoutine(); // Play Spare Animation
                }
            }

            else if (ballTrigger)   // Turn 2
            {
                turn = 0;
                frame++;
                ballTrigger = false;

                spareCount = PinsTriggerL.PinsKnocked;
                spareCount -= tempCount;

                ScoreManager.PinsCountL += spareCount;    // Add Score

                StartCoroutine(LaneReset());
            }
        }

        else
        {
            if (turn == 1 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerL.PinsKnocked == 10)    // If Strike
                {
                    strike = true;
                    ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    tempCount = PinsTriggerL.PinsKnocked;
                    ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;
                    SpareRoutine(); // Play Spare Animation
                }
            }

            else if (turn == 2 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerL.PinsKnocked == 10)    // If Strike or Spare
                {
                    spare = true;

                    if (strike)
                    {
                        ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;    // Add Score
                    }

                    else
                    {
                        spareCount = PinsTriggerL.PinsKnocked;
                        spareCount -= tempCount;
                        ScoreManager.PinsCountL += spareCount;    // Add Score
                    }
                    
                    Debug.Log("Left Total Score: " + ScoreManager.PinsCountL);

                    StartCoroutine(LaneReset());
                }

                else
                {
                    if (strike)
                    {
                        spare = true;

                        tempCount = PinsTriggerL.PinsKnocked;
                        ScoreManager.PinsCountL += PinsTriggerL.PinsKnocked;    // Add Score
                        Debug.Log("Left Total Score: " + ScoreManager.PinsCountL);

                        SpareRoutine();
                    }

                    else
                    {
                        spareCount = PinsTriggerL.PinsKnocked;
                        spareCount -= tempCount;

                        ScoreManager.PinsCountL += spareCount;    // Add Score
                        Debug.Log("Left Total Score: " + ScoreManager.PinsCountL);

                        PinsTriggerL.Active = false;

                        Debug.Log("Left Game Ended");

                        StartCoroutine(LaneReset());
                    }
                }
            }

            else if (spare && ballTrigger)  // 3rd Attempt only if 2nd Attempt is a strike or spare
            {
                spare = false;

                spareCount = PinsTriggerL.PinsKnocked;
                spareCount -= tempCount;

                ScoreManager.PinsCountL += spareCount;    // Add Score
                Debug.Log("Left Total Score: " + ScoreManager.PinsCountL);

                PinsTriggerL.Active = false;

                Debug.Log("Left Game Ended");

                StartCoroutine(LaneReset());
            }
        }
    }

    private IEnumerator BallTrigger()
    {
        yield return new WaitForSeconds(5f);

        ballTrigger = true;
    }

    private IEnumerator LaneStart()
    {
        yield return new WaitForSeconds(1f);

        PinsTriggerL.Active = true;
    }

    private IEnumerator LaneReset()
    {
        PinsTriggerL.Active = false;

        yield return new WaitForSeconds(5f);

        BallBlockerL.SetTrigger("Trigger");

        yield return new WaitForSeconds(3f);

        pinsManager.toggleL = true;

        yield return new WaitForSeconds(4f);

        PinsTriggerL.Active = true;
        PinsTriggerL.PinsKnocked = 0;

        Debug.Log("Left Frame: " + frame + "Turn: " + turn);
        Debug.Log("Left Total Score: " + ScoreManager.PinsCountL);
    }
}