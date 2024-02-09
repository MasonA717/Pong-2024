using UnityEngine;

public class SurfaceBounce : MonoBehaviour {
    public float bounceSpeed = 10f;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        
        if (ball != null) {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * bounceSpeed);
        }
    }
}