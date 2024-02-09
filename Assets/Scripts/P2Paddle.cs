using UnityEngine;

public class P2Paddle : DemoPaddle
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0f)
        {
            if (ball.position.y > GetComponent<Rigidbody2D>().position.y)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * UnitsPerSecond);
            }
            else if (ball.position.y < GetComponent<Rigidbody2D>().position.y)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.down * UnitsPerSecond);
            }
        }
        else
        {
            if (GetComponent<Rigidbody2D>().position.y > 0f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.down * UnitsPerSecond);
            }
            else if (GetComponent<Rigidbody2D>().position.y < 0f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * UnitsPerSecond);
            }
        }
    }
}
