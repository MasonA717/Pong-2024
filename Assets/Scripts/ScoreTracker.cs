using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Ball ball;
    public TextMeshPro P1ScoreText, P2ScoreText;

    private int P1Score = 0;
    private int P2Score = 0;

    public void P1Scores()
    {
        P1Score++;
        P1ScoreText.text = P1Score.ToString();

        Debug.Log("Player 1 scores! Current score: Player 1 - " + P1Score + ", Player 2 - " + P2Score);

        CheckGameEnd();
        ball.ResetPosition(true); // Sending the ball to Player 1
    }

    public void P2Scores()
    {
        P2Score++;
        P2ScoreText.text = P2Score.ToString();

        Debug.Log("Player 2 scores! Current score: Player 1 - " + P1Score + ", Player 2 - " + P2Score);

        CheckGameEnd();
        ball.ResetPosition(false); // Sending the ball to Player 2
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
        else
        {
            Debug.Log("Game Over, right paddle wins!");
        }

        // Reset scores to 0-0
        P1Score = 0;
        P2Score = 0;
        P1ScoreText.text = "0";
        P2ScoreText.text = "0";
    }
}