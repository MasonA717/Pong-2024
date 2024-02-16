using UnityEngine;

public class Ball : MonoBehaviour
{
    public float unitsPerSecond = 5f;
    private float currentSpeed;
    public Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip hitSound1, hitSound2, scoreSound;

    private bool isPowerUpActive = false;
    private float powerUpSpeedIncrease = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = unitsPerSecond;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

        // Try to find an existing AudioSource component
        audioSource = GetComponent<AudioSource>();

        // If AudioSource component doesn't exist, create and configure it
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }

        // Load audio clips
        hitSound1 = Resources.Load<AudioClip>("BallHit1");
        hitSound2 = Resources.Load<AudioClip>("BallHit2");
        scoreSound = Resources.Load<AudioClip>("ScoreUp");
    }

    private void Start()
    {
        ResetPosition();
    }

    public void AddStartingForce()
    {
        // Calculate the initial movement angle with a minimum angle
        float minAngle = -90f;
        float angle = Random.Range(minAngle, 360f - minAngle);

        // Convert angle to radians
        float radians = angle * Mathf.Deg2Rad;

        // Calculate the normalized movement vector based on the angle
        Vector2 movement = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

        rb.AddForce(movement * currentSpeed, ForceMode2D.Impulse);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force * currentSpeed);
    }

    public void IncrementSpeed(float increment)
    {
        currentSpeed += increment;
    }

    public void ActivatePowerUp()
    {
        isPowerUpActive = true;
    }

    public void DeactivatePowerUp()
    {
        isPowerUpActive = false;
    }

    public void ResetPosition()
    {
        audioSource.PlayOneShot(scoreSound);
        rb.velocity = Vector2.zero;
        rb.position = Vector2.zero;
        currentSpeed = unitsPerSecond;
        isPowerUpActive = false; // Reset power-up state
        AddStartingForce();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayHitSound();
    }

    private void PlayHitSound()
    {
        // Check the speed and play the corresponding sound
        if (Mathf.Abs(rb.velocity.magnitude) <= 10f)
        {
            audioSource.clip = hitSound1;
        }
        else
        {
            audioSource.clip = hitSound2;
        }

        // Play the selected sound
        audioSource.Play();
    }

    private void Update()
    {
        // Adjust the speed based on the power-up state
        float currentSpeedWithPowerUp = isPowerUpActive ? currentSpeed + powerUpSpeedIncrease : currentSpeed;
        rb.velocity = rb.velocity.normalized * currentSpeedWithPowerUp;
    }
}