using System.Collections;
using UnityEngine;

public class BallTriggerL : MonoBehaviour
{
    public Animator BallBlockerL;
    public PinsManager pinsManager;

    private bool ballTrigger = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            ballTrigger = true;
            Debug.Log("Bowling Ball exited the trigger!");
        }
    }

    private void Start()
    {
        StartCoroutine(LaneStart());
    }

    private void Update()
    {
        if (ballTrigger)
        {
            ballTrigger = false;
            StartCoroutine(LaneReset());
        }
    }

    private IEnumerator LaneStart()
    {
        yield return new WaitForSeconds(1f);
        PinsTriggerL.Active = true;
    }

    private IEnumerator LaneReset()
    {
        yield return new WaitForSeconds(5f);
        BallBlockerL.SetTrigger("Trigger");
        yield return new WaitForSeconds(3f);

        PinsTriggerL.Active = false; // stop counting after reset
        pinsManager.toggleL = true;
        yield return new WaitForSeconds(5f);
        PinsTriggerL.Active = true;
    }
}
