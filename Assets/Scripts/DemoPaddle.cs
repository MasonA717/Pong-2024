using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    public float speedIncrement = 10f;
    private float currentSpeed = 10f;

    public float UnitsPerSecond
    {
        get { return currentSpeed; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball != null)
            {
                ball.AddForce(transform.right * currentSpeed);
                // currentSpeed += speedIncrement;
            }
        }
    }
}
