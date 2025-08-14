using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaneStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (ballTrigger)
        {
            ballTrigger = false;

            StartCoroutine(LaneReset());
        }
    }

    IEnumerator LaneStart()
    {
        yield return new WaitForSeconds(1f);

        PinsTriggerL.Active = true;
    }

    private IEnumerator LaneReset()
    {
        yield return new WaitForSeconds(5);

        BallBlockerL.SetTrigger("Trigger");

        yield return new WaitForSeconds(3f);

        pinsManager.toggleL = true;
    }
}