/*
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public PinsManager pinsManager;
    public bool useLeftLane = true;

    private List<int> rolls = new List<int>();
    private int currentRollPinsRemaining = 10;
    private int currentFrame = 1;
    private int rollInFrame = 1;
    private bool gameOver = false;

    void Start()
    {
        UpdateScoreText();
    }

    public void OnRollEnd()
    {
        if (gameOver) return;

        int knockedOver = CountKnockedPins();
        rolls.Add(knockedOver);

        if (currentFrame < 10)
        {
            if (rollInFrame == 1)
            {
                if (knockedOver == 10)
                {
                    EndFrame();
                }
                else
                {
                    rollInFrame = 2;
                    currentRollPinsRemaining -= knockedOver;
                }
            }
            else
            {
                EndFrame();
            }
        }
        else
        {
            HandleTenthFrame(knockedOver);
        }

        UpdateScoreText();
    }

    private void EndFrame()
    {
        currentFrame++;
        rollInFrame = 1;
        currentRollPinsRemaining = 10;
        ResetPins();

        if (currentFrame > 10)
        {
            gameOver = true;
        }
    }

    private void HandleTenthFrame(int knockedOver)
    {
        if (rollInFrame == 1)
        {
            rollInFrame = 2;
            currentRollPinsRemaining = (knockedOver == 10) ? 10 : (10 - knockedOver);
            if (knockedOver == 10) ResetPins();
        }
        else if (rollInFrame == 2)
        {
            bool firstRollStrike = rolls[rolls.Count - 2] == 10;
            bool isSpare = rolls[rolls.Count - 2] + knockedOver == 10;

            if (firstRollStrike || isSpare)
            {
                rollInFrame = 3;
                currentRollPinsRemaining = 10;
                ResetPins();
            }
            else
            {
                gameOver = true;
            }
        }
        else
        {
            gameOver = true;
        }
    }

    private int CalculateScore()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rollIndex >= rolls.Count) break;

            if (rolls[rollIndex] == 10)
            {
                score += 10 + StrikeBonus(rollIndex);
                rollIndex++;
            }
            else if (rollIndex + 1 < rolls.Count && rolls[rollIndex] + rolls[rollIndex + 1] == 10)
            {
                score += 10 + SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else
            {
                score += rolls[rollIndex] + ((rollIndex + 1 < rolls.Count) ? rolls[rollIndex + 1] : 0);
                rollIndex += 2;
            }
        }
        return score;
    }

    private int StrikeBonus(int rollIndex)
    {
        int bonus = 0;
        if (rollIndex + 1 < rolls.Count) bonus += rolls[rollIndex + 1];
        if (rollIndex + 2 < rolls.Count) bonus += rolls[rollIndex + 2];
        return bonus;
    }

    private int SpareBonus(int rollIndex)
    {
        if (rollIndex + 2 < rolls.Count) return rolls[rollIndex + 2];
        return 0;
    }

    private void UpdateScoreText()
    {
        int score = CalculateScore();
        scoreText.text = $"Frame: {currentFrame} | Score: {score}";
    }

    private int CountKnockedPins()
    {
        GameObject pinParent = useLeftLane ? pinsManager.lPins : pinsManager.rPins;
        int knockedOver = 0;

        foreach (Transform pin in pinParent.transform)
        {
            if (Vector3.Angle(Vector3.up, pin.up) > 45f)
            {
                knockedOver++;
            }
        }

        return knockedOver;
    }

    private void ResetPins()
    {
        if (useLeftLane)
            pinsManager.toggleL = true;
        else
            pinsManager.toggleR = true;
    }
}
*/