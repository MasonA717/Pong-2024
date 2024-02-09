using UnityEngine;

public class Ball : MonoBehaviour
{
    public float unitsPerSecond = 10f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartingForce();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);

        Vector2 movement = new Vector2(x, y);
        rb.AddForce(movement * unitsPerSecond);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void ResetPosition(bool sendToPlayer1)
    {
        rb.velocity = Vector2.zero;

        if (sendToPlayer1)
            rb.position = new Vector2(-8f, 0f);
        else
            rb.position = new Vector2(8f, 0f);

        AddStartingForce();
    }
}