using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerR : MonoBehaviour
{
    public Animator BallBlockerR;

    public PinsManager pinsManager;

    private bool ballTrigger = false;
    private bool spare = false;
    private bool strike = false;

    public static int frame = 10;

    private int turn = 0;
    private int tempCount = 0;
    private int spareCount = 0;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            turn++;
            StartCoroutine(BallTrigger());

            Debug.Log("Right Frame: " + frame + " Turn: " + turn);
        }
    }

    public void SpareRoutine()
    {
        BallBlockerR.SetTrigger("Trigger");
        pinsManager.toggleR2 = true;
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

                if (PinsTriggerR.PinsKnocked == 10)    // If Strike
                {
                    turn = 0;
                    frame++;

                    ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    tempCount = PinsTriggerR.PinsKnocked;
                    ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;
                    SpareRoutine(); // Play Spare Animation
                }
            }

            else if (ballTrigger)   // Turn 2
            {
                turn = 0;
                frame++;
                ballTrigger = false;

                spareCount = PinsTriggerR.PinsKnocked;
                spareCount -= tempCount;

                ScoreManager.PinsCountR += spareCount;    // Add Score

                StartCoroutine(LaneReset());
            }
        }

        else
        {
            if (turn == 1 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerR.PinsKnocked == 10)    // If Strike
                {
                    strike = true;
                    ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    tempCount = PinsTriggerR.PinsKnocked;
                    ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;
                    SpareRoutine(); // Play Spare Animation
                }
            }

            else if (turn == 2 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerR.PinsKnocked == 10)    // If Strike or Spare
                {
                    spare = true;

                    if (strike)
                    {
                        ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;    // Add Score
                    }

                    else
                    {
                        spareCount = PinsTriggerR.PinsKnocked;
                        spareCount -= tempCount;
                        ScoreManager.PinsCountR += spareCount;    // Add Score
                    }

                    Debug.Log("Right Total Score: " + ScoreManager.PinsCountR);

                    StartCoroutine(LaneReset());
                }

                else
                {
                    if (strike)
                    {
                        spare = true;

                        tempCount = PinsTriggerR.PinsKnocked;
                        ScoreManager.PinsCountR += PinsTriggerR.PinsKnocked;    // Add Score
                        Debug.Log("Right Total Score: " + ScoreManager.PinsCountR);

                        SpareRoutine();
                    }

                    else
                    {
                        spareCount = PinsTriggerR.PinsKnocked;
                        spareCount -= tempCount;

                        ScoreManager.PinsCountR += spareCount;    // Add Score
                        Debug.Log("Right Total Score: " + ScoreManager.PinsCountR);

                        PinsTriggerR.Active = false;

                        Debug.Log("Right Game Ended");

                        StartCoroutine(LaneReset());
                    }
                }
            }

            else if (spare && ballTrigger)  // 3rd Attempt only if 2nd Attempt is a strike or spare
            {
                spare = false;

                spareCount = PinsTriggerR.PinsKnocked;
                spareCount -= tempCount;

                ScoreManager.PinsCountR += spareCount;    // Add Score
                Debug.Log("Right Total Score: " + ScoreManager.PinsCountR);

                PinsTriggerR.Active = false;

                Debug.Log("Right Game Ended");

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

        PinsTriggerR.Active = true;
    }

    private IEnumerator LaneReset()
    {
        PinsTriggerR.Active = false;

        yield return new WaitForSeconds(5f);

        BallBlockerR.SetTrigger("Trigger");

        yield return new WaitForSeconds(3f);

        pinsManager.toggleR = true;

        yield return new WaitForSeconds(4f);

        PinsTriggerR.Active = true;
        PinsTriggerR.PinsKnocked = 0;

        Debug.Log("Right Frame: " + frame + " Turn: " + turn);
        Debug.Log("Right Total Score: " + ScoreManager.PinsCountR);
    }
}