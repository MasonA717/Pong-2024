using UnityEngine;

public class P1Paddle : DemoPaddle
{
    private Vector2 movement;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement = Vector2.down;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (movement.sqrMagnitude != 0)
        {
            GetComponent<Rigidbody2D>().AddForce(movement * UnitsPerSecond);
        }
    }
}