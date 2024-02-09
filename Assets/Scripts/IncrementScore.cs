using UnityEngine;
using UnityEngine.Events;

public class IncrementScore : MonoBehaviour {
    public UnityEvent scoreTrigger;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        
        if (ball != null) {
            scoreTrigger.Invoke();
        }
    }
}
