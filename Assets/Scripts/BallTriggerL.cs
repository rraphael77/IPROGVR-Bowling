using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BallTriggerL : MonoBehaviour
{
    public Animator BallBlockerL;
    public PinsManager pinsManager;

    private bool ballTrigger = false;
    private bool spare = false;

    public static int frame = 10;

    private int turn = 0;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            turn++;
            StartCoroutine(BallTrigger());

            Debug.Log("Frame: " + frame + "Turn: " + turn);
        }
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

                if (PinsTriggerL.PinsKnockedL == 10)    // If Strike
                {
                    turn = 0;
                    frame++;

                    ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    // Play Spare Animation
                }
            }

            else if (ballTrigger)   // Turn 2
            {
                turn = 0;
                frame++;
                ballTrigger = false;

                ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score

                StartCoroutine(LaneReset());
            }
        }

        else
        {
            if (turn == 1 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerL.PinsKnockedL == 10)    // If Strike
                {
                    ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score

                    StartCoroutine(LaneReset());
                }

                else
                {
                    // Play Spare Animation
                }
            }

            else if (turn == 2 && ballTrigger)
            {
                ballTrigger = false;

                if (PinsTriggerL.PinsKnockedL == 10)    // If Strike or Spare
                {
                    spare = true;

                    ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score
                    Debug.Log("Total Score: " + ScoreManager.PinsCount);

                    StartCoroutine(LaneReset());
                }

                else
                {
                    frame = 0;

                    ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score
                    Debug.Log("Total Score: " + ScoreManager.PinsCount);

                    ScoreManager.Game++;
                    Debug.Log("Game Ended");
                    // End Game
                }
            }

            else if (spare && ballTrigger)  // 3rd Attempt only if 2nd Attempt = 10
            {
                frame = 0;

                ScoreManager.PinsCount += PinsTriggerL.PinsKnockedL;    // Add Score
                Debug.Log("Total Score: " + ScoreManager.PinsCount);

                ScoreManager.Game++;
                Debug.Log("Game Ended");
                // End Game

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
        PinsTriggerL.PinsKnockedL = 0;

        Debug.Log("Frame: " + frame + "Turn: " + turn);
        Debug.Log("Total Score: " + ScoreManager.PinsCount);
    }
}