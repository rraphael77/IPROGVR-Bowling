/*
using System.Collections;
using UnityEngine;

public class Return : MonoBehaviour
{
    public Ball ball;
    public Ball ball2;
    public Ball ball3;
    public PinManager pinManager;
    public BowlingScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball.gameObject)
        {
            ball.ResetBall();
            StartCoroutine(HandleRollEnd());
        }
        else if (other.gameObject == ball2.gameObject)
        {
            ball2.ResetBall();
            StartCoroutine(HandleRollEnd());
        }
        else if (other.gameObject == ball3.gameObject)
        {
            ball3.ResetBall();
            StartCoroutine(HandleRollEnd());
        }
    }

    private IEnumerator HandleRollEnd()
    {
        yield return new WaitForSeconds(3f);
        if (scoreManager != null)
        {
            scoreManager.OnRollEnd();
        }
        else
        {
            Debug.LogWarning("BowlingScoreManager not assigned in Return script.");
        }
    }
}
*/