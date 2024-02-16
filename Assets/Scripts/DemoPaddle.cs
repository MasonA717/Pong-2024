using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    private float paddleSpeed = 10f;
    private float defaultPaddleScale;
    private bool isPowerUpActive = false;

    public float UnitsPerSecond
    {
        get { return isPowerUpActive ? paddleSpeed * 2f : paddleSpeed; } // Adjust speed during power-up
    }

    private void Awake()
    {
        // Store the default paddle scale
        defaultPaddleScale = transform.localScale.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball != null)
            {
                ball.IncrementSpeed(1f);
            }
        }
    }

    // Method to decrease the paddle size by a given scale factor
    public void DecreasePaddleSize(float scale)
    {
        // Ensure the scale is within valid bounds
        float newScale = Mathf.Clamp(defaultPaddleScale * scale, 0.1f, 1f);

        // Apply the new scale to the paddle
        transform.localScale = new Vector3(transform.localScale.x, newScale, 1f);
    }

    // Method to increase the paddle speed
    public void IncreaseSpeed(float speedIncrease)
    {
        paddleSpeed += speedIncrease;
    }

    // Method to reset power-up effects
    public void ResetPowerUpEffects()
    {
        // Reset paddle scale and speed to their default values
        transform.localScale = new Vector3(transform.localScale.x, defaultPaddleScale, 1f);
        paddleSpeed = 10f;
        isPowerUpActive = false;
    }

    // Method to activate power-up effects
    public void ActivatePowerUp()
    {
        isPowerUpActive = true;
    }
}