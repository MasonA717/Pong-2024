using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Ball ball;
    public Text P1ScoreText, P2ScoreText;

    private int P1Score = 0;
    private int P2Score = 0;

    public void P1Scores()
    {
        P1Score++;
        P1ScoreText.text = P1Score.ToString();

        Debug.Log("Player 1 scores! Current score: Player 1 - " + P1Score + ", Player 2 - " + P2Score);

        CheckGameEnd();
        ball.ResetPosition();
        UpdateScoreColor();
    }

    public void P2Scores()
    {
        P2Score++;
        P2ScoreText.text = P2Score.ToString();

        Debug.Log("Player 2 scores! Current score: Player 1 - " + P1Score + ", Player 2 - " + P2Score);

        CheckGameEnd();
        ball.ResetPosition();
        UpdateScoreColor();
    }

    private void CheckGameEnd()
    {
        if (P1Score >= 11 || P2Score >= 11)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (P1Score > P2Score)
        {
            Debug.Log("Game Over, left paddle wins!");
        }
        else {
            Debug.Log("Game Over, right paddle wins!");
        }

        // Reset scores to 0-0
        P1Score = 0;
        P2Score = 0;
        P1ScoreText.text = "0";
        P2ScoreText.text = "0";
    }

    private void UpdateScoreColor()
    {
        // Change color based on the score range
        ChangeScoreColor(P1ScoreText, P1Score);
        ChangeScoreColor(P2ScoreText, P2Score);
    }

    private void ChangeScoreColor(Text scoreText, int score)
    {
        Color color;

        if (score == 0)
        {
            color = Color.white;
        }
        else if (score >= 2 && score <= 4)
        {
            color = Color.blue;
        }
        else if (score >= 5 && score <= 7)
        {
            color = Color.green;
        }
        else if (score >= 8 && score <= 10)
        {
            color = Color.red;
        }
        else
        {
            color = Color.white;
        }

        scoreText.color = color;
    }
}