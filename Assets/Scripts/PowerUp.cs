using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedIncrease = 5f;
    public float paddleSizeDecrease = 0.5f;
    public AudioClip pickupSound;

    private float powerUpDuration = 10f;
    private float timer;
    private DemoPaddle affectedPaddle;

    private void Update()
    {
        // Update the timer only if the power-up has been picked up
        if (affectedPaddle != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                // If the duration has elapsed, remove power-up effects
                RemovePowerUpEffects();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball ball = other.GetComponent<Ball>();

            if (ball != null)
            {
                // Determine which player picked up the power-up based on the ball's current velocity
                float horizontalVelocity = ball.rb.velocity.x;

                if (horizontalVelocity < 0f)
                {
                    // Player 1 picked up the power-up
                    affectedPaddle = FindObjectOfType<P1Paddle>();
                }
                else if (horizontalVelocity > 0f)
                {
                    // Player 2 picked up the power-up
                    affectedPaddle = FindObjectOfType<P2Paddle>();
                }

                // Apply power-up effects
                ApplyPowerUpEffects();
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                // Destroy the power-up object instantly upon pickup
                Destroy(gameObject);
            }
        }
    }

    private void ApplyPowerUpEffects()
    {
        // Apply the power-up effects based on the player who picked it up
        if (affectedPaddle != null)
        {
            affectedPaddle.IncreaseSpeed(speedIncrease);
            affectedPaddle.DecreasePaddleSize(paddleSizeDecrease);
            StartPowerUpTimer();
        }
    }

    // Function to start the power-up timer
    private void StartPowerUpTimer()
    {
        timer = powerUpDuration;
    }

    // Function to remove power-up effects
    private void RemovePowerUpEffects()
    {
        if (affectedPaddle != null)
        {
            affectedPaddle.ResetPowerUpEffects();
            affectedPaddle = null; // Reset affectedPaddle after removing effects
        }
    }
}
