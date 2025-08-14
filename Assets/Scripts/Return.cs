using System.Collections;
using UnityEngine;

public class Return : MonoBehaviour
{
    public Ball ball;
    public Ball ball2;
    public Ball ball3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball.gameObject)
        {
            ball.ResetBall();
        }
        else if (other.gameObject == ball2.gameObject)
        {
            ball2.ResetBall();
        }
        else if (other.gameObject == ball3.gameObject)
        {
            ball3.ResetBall();
        }
    }
}